using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // �e�ۂ̑��x
    public float lifeTime = 5f; // �e�ۂ̎����i�b�j

    private void Start()
    {
        // ��莞�Ԍ�ɒe�ۂ�j�󂷂�
        Destroy(gameObject, lifeTime);
    }
}