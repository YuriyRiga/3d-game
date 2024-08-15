using UnityEngine;
using UnityEngine.Pool;
using System.Collections;
using System;

public abstract class Spawner<T> : MonoBehaviour where T : Objects
{
    [SerializeField] private T _prefab;
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<T> _pool;

    public event Action ObjectCreated;
    public event Action ObjectSpawn;
    public event Action<int> ObjectActivated;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Instantiate(),
            actionOnGet: (obj) => InitializeObject(obj),
            actionOnRelease: (obj) => Disable(obj),
            actionOnDestroy: (obj) => Unsubscribe(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public int GetNumberActiveObject()
    {
        return _pool.CountActive;
    }

    private T Instantiate()
    {
        T obj = Instantiate(_prefab);
        Subscribe(obj);
        ObjectCreated?.Invoke();
        return obj;
    }

    private void Subscribe(T obj)
    {
        obj.ObjectDisable += OnObjectsDisable;
    }

    private void Unsubscribe(T obj)
    {
        obj.ObjectDisable -= OnObjectsDisable;
        Destroy(obj.gameObject);
    }

    protected virtual void OnObjectsDisable(Objects objectsSpawn)
    {
        if (objectsSpawn != null)
        {
            Release(objectsSpawn as T);
        }
    }

    protected virtual void InitializeObject(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void Disable(T item)
    {
        item.gameObject.SetActive(false);
    }

    private void Release(T item)
    {
        _pool.Release(item);
    }

    protected void ActivateObject()
    {
        _pool.Get();
        ObjectSpawn?.Invoke();
        ObjectActivated?.Invoke(GetNumberActiveObject());
    }

    protected IEnumerator SpawnCouldown()
    {
        var delay = new WaitForSeconds(_repeatRate);

        while (gameObject.activeSelf)
        {
            ActivateObject();
            yield return delay;
        }
    }
}
