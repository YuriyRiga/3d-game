using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private float minTime = 2f;
    [SerializeField] private float maxTime = 5f;
    [SerializeField] private Cube _cube;

    private ObjectPool<Cube> _objectPool;
    private bool _isReturningToPool = false;

    public void SetPool(ObjectPool<Cube> objectPool)
    {
        _objectPool = objectPool;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & platformLayer) != 0 && _isReturningToPool == false)
        {
            _isReturningToPool = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(ReturnToPoolAfterRandomTime());
        }
    }

    private IEnumerator ReturnToPoolAfterRandomTime()
    {
        float waitTime = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);

        _objectPool?.Release(_cube);
        _isReturningToPool = false;
    }
}
