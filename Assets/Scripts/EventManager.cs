using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public event Action ObjectSpawnedGlobal;
    public event Action ObjectCreatedGlobal;
    public event Action<bool> ObjectActivatedGlobal;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RaiseObjectSpawned() => ObjectSpawnedGlobal?.Invoke();
    public void RaiseObjectCreated() => ObjectCreatedGlobal?.Invoke();
    public void RaiseObjectActivated(bool value) => ObjectActivatedGlobal?.Invoke(value);
}