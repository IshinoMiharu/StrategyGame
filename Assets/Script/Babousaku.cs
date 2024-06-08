using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babousaku : MonoBehaviour
{
    public string team;         // �w�c�̖��O
    public int maxHP = 100;     // �ő�HP
    public int minAttackDamage = 10; // �ŏ��U���_���[�W
    public int maxAttackDamage = 20; // �ő�U���_���[�W
    public float attackFrequency = 1f; // �U���p�x�i1�b������̍U���񐔁j
    public float attackRange = 1f; // �U���͈�

    private float lastAttackTime; // �O��̍U������

    private void Start()
    {
        lastAttackTime = Time.time;

    }

    private void Update()
    {
        if (CanAttack())
        {
            Attack();
        }

    }
   

    private bool CanAttack()
    {
        return Time.time >= lastAttackTime + (1f / attackFrequency);
    }

    private void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Unit") && collider.gameObject.GetComponent<Unit>().team != team)
            {
                int damage = Random.Range(minAttackDamage, maxAttackDamage + 1); // minAttackDamage�ȏ�maxAttackDamage�ȉ��̗����𐶐�
                collider.gameObject.GetComponent<Unit>().TakeDamage(damage);
                Debug.Log($"{gameObject.name} attacked {collider.gameObject.name} with {damage} damage. Current HP: {collider.gameObject.GetComponent<Unit>().GetCurrentHP()}");


            }
        }
        lastAttackTime = Time.time;
    }

    public void TakeDamage(int damage)
    {
        maxHP -= damage;
        if (maxHP <= 0)
        {
            Die();
        }


    }

    public int GetCurrentHP()
    {
        return maxHP;
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} from team {team} died.");
        Destroy(gameObject);
    }


}
