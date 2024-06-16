using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    [SerializeField] private float _duration  = 0.01f;
    [SerializeField] private float _elapsedTime = 0f;
    [SerializeField] private Vector3 _finishScale = new Vector3(3f, 3f, 3f);
    [SerializeField] private Vector3 _startScale = new Vector3(1f, 1f, 1f);
    [SerializeField] private GameObject m_capsule;

    private void Update()
    {
        if (_elapsedTime < _duration)
        {
            _elapsedTime += Time.deltaTime; 
            float time = _elapsedTime / _duration;
            m_capsule.transform.localScale = Vector3.Lerp(_startScale, _finishScale, time);
        }
    }
}
