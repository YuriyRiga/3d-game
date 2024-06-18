using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ñounter : MonoBehaviour
{
    [SerializeField] private float _stepTime = 0.5f;
    [SerializeField] private float _stepsCount = 0f;

    public event Action<float> StepCountChanged;
    private bool _isWork = true;
    private Coroutine _coroutine;

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
        while (_isWork)
        {
            ++_stepsCount;
            StepCountChanged.Invoke(_stepsCount);
            yield return new WaitForSecondsRealtime(_stepTime);
        }
    }
}
