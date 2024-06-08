using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babousaku : MonoBehaviour
{
    public string team;         // êwâcÇÃñºëO
    public int maxHP = 100;     // ç≈ëÂHP
    public int minAttackDamage = 10; // ç≈è¨çUåÇÉ_ÉÅÅ[ÉW
    public int maxAttackDamage = 20; // ç≈ëÂçUåÇÉ_ÉÅÅ[ÉW
    public float attackFrequency = 1f; // çUåÇïpìxÅi1ïbÇ†ÇΩÇËÇÃçUåÇâÒêîÅj
    public float attackRange = 1f; // çUåÇîÕàÕ

    private float lastAttackTime; // ëOâÒÇÃçUåÇéûçè

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
                int damage = Random.Range(minAttackDamage, maxAttackDamage + 1); // minAttackDamageà»è„maxAttackDamageà»â∫ÇÃóêêîÇê∂ê¨
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
