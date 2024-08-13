public class ActiveObjectCounter : Counter
{
    private void OnEnable()
    {
        EventManager.Instance.ObjectActivatedGlobal += OnChange;
    }

    private void OnDisable()
    {
        EventManager.Instance.ObjectActivatedGlobal -= OnChange;
    }

    protected override void OnChange(bool value)
    {
        if (value)
        {
            _count++;
        }
        else
        {
            _count--;
        }

        base.OnChange(value);
    }
}
