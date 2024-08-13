public class SpawnObjectCounter : Counter
{
    private void OnEnable()
    {
        EventManager.Instance.ObjectSpawnedGlobal += OnChange;
    }

    private void OnDisable()
    {
        EventManager.Instance.ObjectSpawnedGlobal -= OnChange;
    }

    protected override void OnChange()
    {
        _count++;
        base.OnChange();
    }
}
