using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _stepTime = 0.5f;
    [SerializeField] private float _timer = 0f;
    [SerializeField] private Text _text;

    private bool _isWork = true;
    private Coroutine _coroutine;

    private void Start()
    {
        UpdateTimerText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(OnTimer());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator OnTimer()
    {
        while (_isWork)
        {
            ++_timer;
            UpdateTimerText();
            yield return new WaitForSecondsRealtime(_stepTime);
        }
    }

    private void UpdateTimerText()
    {
        _text.text = _timer.ToString("");
    }
}
