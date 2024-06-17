using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.5f;
    [SerializeField] private GameObject _sphere;

    private void Update()
    {
        var nextPosition = _sphere.transform.position;
        nextPosition.x += _moveSpeed * Time.deltaTime;
        _sphere.transform.position = nextPosition;
    }
}
