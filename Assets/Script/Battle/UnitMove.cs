using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public float moveSpeed = 5f; // ���j�b�g�̈ړ����x

    private bool isSelected = false;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private Vector3 direction;

    void Update()
    {
        // ���j�b�g�̑I��
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isSelected = true;
                Debug.Log("Unit Selected");
            }
            else
            {
                isSelected = false;
            }
        }

        // �ړI�n�̐ݒ�
        if (isSelected && Input.GetMouseButtonDown(1))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0; // Z���̒l��0�ɐݒ�
            direction = (targetPosition - transform.position).normalized;
            isMoving = true;
        }

        // ���j�b�g�̈ړ�
        if (isMoving)
        {
            RotateTowardsTarget(targetPosition);

            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false;
            }
        }
    }

    void RotateTowardsTarget(Vector3 targetPosition)
    {
        Vector3 lookDirection = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}