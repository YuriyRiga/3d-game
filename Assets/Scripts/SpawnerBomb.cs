using UnityEngine;

public class SpawnerBomb : Spawner<Bomb>
{
    [SerializeField] private Cube _cube;

    private Transform _position;

    public void Create(Objects objects)
    {
        _position = objects.transform;
        ActivateObject();
    }
    protected override void InitializePool(Bomb obj)
    {
        obj.transform.position = _position.transform.position;
        base.InitializePool(obj);
    }
}
