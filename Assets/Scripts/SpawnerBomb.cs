using UnityEngine;

public class SpawnerBomb : Spawner<Bomb>
{
    private Transform _position;

    public void Create(Objects objects)
    {
        _position = objects.transform;
        ActivateObject();
    }

    protected override void InitializeObject(Bomb obj)
    {
        obj.transform.position = _position.transform.position;
        base.InitializeObject(obj);
    }
}
