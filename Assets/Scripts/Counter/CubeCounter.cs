using UnityEngine;

public class CubeCounter : Counter<Cube>
{
    [SerializeField] private Spawner<Cube> _spawner;

    private void Start()
    {
        Initialize(_spawner);
    }
}
