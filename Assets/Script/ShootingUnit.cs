using UnityEngine;

public class ShootingUnit : MonoBehaviour
{
    public GameObject bulletPrefab; // ’eŠÛ‚ÌƒvƒŒƒnƒu
    public Transform bulletSpawnPoint; // ’eŠÛ‚Ì”­ŽËˆÊ’u
    public float shootingInterval = 2f; // ’eŠÛ‚ð”­ŽË‚·‚éŠÔŠui•bj

    private float lastShotTime; // ‘O‰ñ‚Ì”­ŽËŽž

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
