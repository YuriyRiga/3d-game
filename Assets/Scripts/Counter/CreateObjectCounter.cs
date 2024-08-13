public class CreateObjectCounter : Counter
{
    private void OnEnable()
    {
        EventManager.Instance.ObjectCreatedGlobal += OnChange;
    }

    private void OnDisable()
    {
        EventManager.Instance.ObjectCreatedGlobal -= OnChange;
    }

    protected override void OnChange()
    {
        _count++;
        base.OnChange();
    }
}
