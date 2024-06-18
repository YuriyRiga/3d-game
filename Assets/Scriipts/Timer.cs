using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _stepTime = 0.5f;
    [SerializeField] private float _stopWatch = 0f;
    [SerializeField] private Text _text;

    private bool _isWork = true;
    private Coroutine _coroutine;

    private void Start()
    {
        UpdateStopwatchText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(OnStopwatch());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator OnStopwatch()
    {
        while (_isWork)
        {
            ++_stopWatch;
            UpdateStopwatchText();
            yield return new WaitForSecondsRealtime(_stepTime);
        }
    }

    private void UpdateStopwatchText()
    {
        _text.text = _stopWatch.ToString("");
    }
}
