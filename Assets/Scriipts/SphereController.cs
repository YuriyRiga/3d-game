using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.5f;
    [SerializeField] private GameObject m_sphere;

    private void Update()
    {
        var nextPosition = m_sphere.transform.position;
        nextPosition.x += _moveSpeed * Time.deltaTime;
        m_sphere.transform.position = nextPosition;
    }
}
