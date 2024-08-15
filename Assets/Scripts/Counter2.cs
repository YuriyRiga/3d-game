using TMPro;
using UnityEngine;

public abstract class Counter2<T> : MonoBehaviour where T : Objects
{
    [SerializeField] private TextMeshProUGUI _textCreatedCount;
    [SerializeField] private TextMeshProUGUI _textSpawnCount;
    [SerializeField] private TextMeshProUGUI _textActivatedCount;
    
    private Spawner<T> _spawner;
    private float _createCount = 0f;
    private float _spawnCount = 0f;

    public void Initialize(Spawner<T> spawner)
    {
        _spawner = spawner;
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        if (_spawner != null)
        {
            _spawner.ObjectCreated += OnObjectCreated;
            _spawner.ObjectSpawn += OnObjectSpawned;
            _spawner.ObjectActivated += OnObjectActivated;
        }
    }

    private void UnsubscribeFromEvents()
    {
        if (_spawner != null)
        {
            _spawner.ObjectCreated -= OnObjectCreated;
            _spawner.ObjectSpawn -= OnObjectSpawned;
            _spawner.ObjectActivated -= OnObjectActivated;
        }
    }

    private void OnObjectCreated()
    {
        _createCount++;
        OnChange(_createCount, _textCreatedCount);
    }

    private void OnObjectSpawned()
    {
        _spawnCount++;
        OnChange(_spawnCount, _textSpawnCount);
    }

    private void OnObjectActivated(float value)
    {
        OnChange(value, _textActivatedCount);
    }

    private void OnChange(float value, TextMeshProUGUI text)
    {
        text.text = value.ToString();
    }
}
