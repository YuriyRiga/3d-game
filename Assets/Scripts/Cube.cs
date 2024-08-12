using System;
using System.Collections;
using UnityEngine;

public class Cube : Objects
{
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private float minTime = 2f;
    [SerializeField] private float maxTime = 5f;

    private bool _hasTouch = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & platformLayer) != 0 && _hasTouch == false)
        {
            _hasTouch = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(Disable());
        }
    }

    private IEnumerator Disable()
    {
        float waitTime = UnityEngine.Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);

        Deactivate();
        _hasTouch = false;
    }
}
