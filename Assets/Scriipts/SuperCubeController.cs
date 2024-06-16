using UnityEngine;

public class SuperCubeController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.5f;
    [SerializeField] private float _duration = 0.01f;
    [SerializeField] private float _elapsedTime = 0f;
    [SerializeField] private float _rotateSpeed = 0.1f;
    [SerializeField] private GameObject m_superCube;
    [SerializeField] private Vector3 _finishScale = new Vector3(3f, 3f, 3f);
    [SerializeField] private Vector3 _startScale = new Vector3(1f, 1f, 1f);
   
    private void Update()
    {
        GetMove();
        GetRotation();
        GetIncrease();
    }

    private void GetMove()
    {
        float direction = _moveSpeed * Time.deltaTime;
        m_superCube.transform.Translate(Vector3.forward * direction);
    }

    private void GetRotation()
    {
        m_superCube.transform.rotation *= Quaternion.Euler(0, _rotateSpeed, 0);
    }

    private void GetIncrease()
    {
        if (_elapsedTime < _duration)
        {
            _elapsedTime += Time.deltaTime;
            float time = _elapsedTime / _duration;
            m_superCube.transform.localScale = Vector3.Lerp(_startScale, _finishScale, time);
        }
    }
}
