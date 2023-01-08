using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyDistance;
    [SerializeField] private Rigidbody _rigidbody;

    public void Init(Vector3 startPosition, Vector3 direction)
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();

        transform.position = startPosition;
        _rigidbody.velocity = direction * _speed;

        float lifeTime = _destroyDistance / _speed;
        StartCoroutine(AutoDestroy(lifeTime));
    }

    private IEnumerator AutoDestroy(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}