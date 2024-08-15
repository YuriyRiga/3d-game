using UnityEngine;

public class BombCounter : Counter<Bomb>
{
    [SerializeField] private Spawner<Bomb> _spawner;

    private void Start()
    {
        Initialize(_spawner);
    }
}
