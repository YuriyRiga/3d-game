using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => InstantiateAndSetup(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private Cube InstantiateAndSetup()
    {
        Cube obj = Instantiate(_prefab).GetComponent<Cube>(); ;
        var collisionHandler = obj?.GetComponent<CollisionHandler>();

        if (collisionHandler != null)
        {
            collisionHandler.SetPool(_pool);
        }

        return obj;
    }

    private void ActionOnGet(Cube obj)
    {
        obj.transform.position = _startPoint.transform.position;
        obj.GetComponent<Renderer>().material.color = Color.white;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.SetActive(true);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _repeatRate);
    }

    private void GetCube()
    {
        _pool.Get();
    }
}
