using UnityEngine;

public class BulletFirePoint : MonoBehaviour
{
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunPoint.position, _gunPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = _gunPoint.forward * _bulletSpeed;

        Destroy(bullet, 5f);
    }
}
