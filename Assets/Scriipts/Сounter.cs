using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class —ounter : MonoBehaviour
{
    [SerializeField] private float _stepTime = 0.5f;
    [SerializeField] private float _watch = 0f;
    [SerializeField] private Text _text;

    private bool _isWork = true;
    private Coroutine _coroutine;

    private void Start()
    {
        Update—ounterText();
    }

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
            ++_watch;
            Update—ounterText();
            yield return new WaitForSecondsRealtime(_stepTime);
        }
    }

    private void Update—ounterText()
    {
        _text.text = _watch.ToString("");
    }
}
