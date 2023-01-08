using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _shotSpeed;
    private float _nextShotTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= _nextShotTime)
            {
                Shot();
                _nextShotTime = Time.time + _shotSpeed;
            }
        }
    }

    private void Shot()
    {
        Bullet bullet = Instantiate(_bullet, _shotPoint.position, transform.rotation);
        bullet.Init(_shotPoint.position, transform.forward);
    }
}
