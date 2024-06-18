using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Ñounter _ñounter;

    private void OnEnable()
    {
        _ñounter.StepCountChanged += OnStepCountChanged;
    }

    private void OnDisable()
    {
        _ñounter.StepCountChanged -= OnStepCountChanged;
    }

    private void OnStepCountChanged(float value)
    {
        Debug.Log(value);
        _text.text = value.ToString("");
    }
}
