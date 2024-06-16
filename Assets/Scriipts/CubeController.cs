using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1;
    [SerializeField] private GameObject m_cube;

    private void Update()
    {
        m_cube.transform.rotation *= Quaternion.Euler(0, _rotateSpeed, 0);
    }
}
