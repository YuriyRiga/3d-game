using System.Collections;
using UnityEngine;

public class Cube : Objects
{
    [SerializeField] private LayerMask _platformLayer;
    [SerializeField] private float _minTime = 2f;
    [SerializeField] private float _maxTime = 5f;

    private bool _hasTouch = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & _platformLayer) != 0 && _hasTouch == false)
        {
            _hasTouch = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(Disable());
        }
    }

    private IEnumerator Disable()
    {
        float waitTime = UnityEngine.Random.Range(_minTime, _maxTime);
        yield return new WaitForSeconds(waitTime);

        Deactivate();
        _hasTouch = false;
    }
}
