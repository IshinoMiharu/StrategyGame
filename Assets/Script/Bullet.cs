using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // ’eŠÛ‚Ì‘¬“x
    public float lifeTime = 5f; // ’eŠÛ‚Ìõ–½i•bj

    private void Start()
    {
        // ˆê’èŠÔŒã‚É’eŠÛ‚ğ”j‰ó‚·‚é
        Destroy(gameObject, lifeTime);
    }
}