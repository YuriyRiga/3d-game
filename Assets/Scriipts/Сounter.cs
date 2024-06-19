using System;
using System.Collections;
using UnityEngine;

public class Ñounter : MonoBehaviour
{
    [SerializeField] private float _stepTime = 0.5f;
    [SerializeField] private float _stepsCount = 0f;

    private Coroutine _coroutine;
    private bool _isWork = true;

    public event Action<float> StepCountChanged;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(OnWatch());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator OnWatch()
    {
        var delay = new WaitForSecondsRealtime(_stepTime);

        while (_isWork)
        {
            ++_stepsCount;
            StepCountChanged?.Invoke(_stepsCount);
            yield return delay;
        }
    }
}
