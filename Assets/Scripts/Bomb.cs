using UnityEngine;
using System.Collections;

public class Bomb : Objects
{
    [SerializeField] private float _fadeDuration = 2f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _upwardModifier = 1f;
    [SerializeField] private int _maxColliders = 10;

    private Renderer _renderer;
    private Color _color;
    private Collider[] _colliders;
    private float _startAlpha = 1f;

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
        _color.a = _startAlpha;
        _renderer.material.color = _color;
        _colliders = new Collider[_maxColliders];
        StartFadeOut();
    }

    private void StartFadeOut()
    {
        Debug.Log("началось");
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;
        float endAlpha = 0f;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.MoveTowards(_startAlpha, endAlpha, elapsedTime / _fadeDuration);
            _color.a = newAlpha;
            _renderer.material.color = _color;
            yield return null;
        }

        _color.a = endAlpha;
        _renderer.material.color = _color;

        Explode();
    }

    private void Explode()
    {
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, _explosionRadius, _colliders);

        for (int i = 0; i < numColliders; i++)
        {
            Collider nearbyObject = _colliders[i];

            if (nearbyObject.TryGetComponent(out Rigidbody rigitbody))
            {
                rigitbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, _upwardModifier, ForceMode.Impulse);
            }
        }

        Deactivate();
    }
}
