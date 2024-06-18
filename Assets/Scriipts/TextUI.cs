using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private �ounter _�ounter;

    private void OnEnable()
    {
        _�ounter.StepCountChanged += OnStepCountChanged;
    }

    private void OnDisable()
    {
        _�ounter.StepCountChanged -= OnStepCountChanged;
    }

    private void OnStepCountChanged(float value)
    {
        Debug.Log(value);
        _text.text = value.ToString("");
    }
}
