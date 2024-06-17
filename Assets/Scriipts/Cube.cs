using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1;
    [SerializeField] private GameObject _cube;

    private void Update()
    {
        _cube.transform.rotation *= Quaternion.Euler(0, _rotateSpeed, 0);
    }
}
