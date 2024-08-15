using System;
using UnityEngine;

public abstract class Objects : MonoBehaviour
{
    public event Action<Objects> ObjectDisable;

    public void Deactivate()
    {
        gameObject.SetActive(false);
        ObjectDisable?.Invoke(this);
    }
}
