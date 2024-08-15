using UnityEngine;

public class SpawnerCube : Spawner<Cube> 
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private SpawnerBomb _spawnerBomb;

    private void Start()
    {
        StartCoroutine(SpawnCouldown());
    }

    protected override void InitializeObject(Cube obj)
    {
        obj.transform.position = _startPoint.transform.position;
        obj.GetComponent<Renderer>().material.color = Color.white;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        base.InitializeObject(obj);
    }

    protected override void OnObjectsDisable(Objects objectsSpawn)
    {
        base.OnObjectsDisable(objectsSpawn);
        _spawnerBomb.Create(objectsSpawn);
    }
}
