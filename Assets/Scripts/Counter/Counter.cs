using TMPro;
using UnityEngine;

public abstract class Counter : MonoBehaviour 
{
    [SerializeField] protected TextMeshProUGUI _textCount;

    protected float _count = 0;

    protected virtual void OnChange()
    {
        _textCount.text = _count.ToString();
    }

    protected virtual void OnChange(bool value)
    {
        _textCount.text = _count.ToString();
    }
}
