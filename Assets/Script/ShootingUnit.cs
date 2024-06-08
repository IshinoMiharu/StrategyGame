using UnityEngine;

public class ShootingUnit : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�ۂ̃v���n�u
    public Transform bulletSpawnPoint; // �e�ۂ̔��ˈʒu
    public float shootingInterval = 2f; // �e�ۂ𔭎˂���Ԋu�i�b�j

    private float lastShotTime; // �O��̔��ˎ���

    private void Start()
    {
        lastShotTime = Time.time;
    }

    private void Update()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }

    private bool CanShoot()
    {
        return Time.time >= lastShotTime + shootingInterval;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bullet.GetComponent<Bullet>().speed;

        lastShotTime = Time.time;
    }
}
