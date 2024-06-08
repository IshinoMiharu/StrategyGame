using UnityEngine;


public class Move : MonoBehaviour
{
    public float speed = 2.0f;
    public float changeDirectionTime = 2.0f;
    public Vector2 movementRange = new Vector2(5.0f, 5.0f);

    // 新たに追加する変数：移動範囲の境界
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private Vector2 targetPosition;
    private float timer;

    void Start()
    {
        SetNewRandomTarget();
        timer = changeDirectionTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SetNewRandomTarget();
            timer = changeDirectionTime;
        }

        MoveTowardsTarget();
    }

    void SetNewRandomTarget()
    {
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        targetPosition = new Vector2(randomX, randomY);
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        // ギズモを使用してエディタで移動範囲を視覚化
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(
            new Vector2((minBounds.x + maxBounds.x) / 2, (minBounds.y + maxBounds.y) / 2),
            new Vector2(maxBounds.x - minBounds.x, maxBounds.y - minBounds.y));
    }
}