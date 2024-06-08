using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName; //�����̖��O
    public string team;         // �w�c�̖��O
    public int maxHP = 10000;     // �ő�HP
    public int currentHP;      // ���݂�HP

    public int minAttackDamage = 10; // �ŏ��U���_���[�W
    public int maxAttackDamage = 20; // �ő�U���_���[�W
    public float attackFrequency = 1f; // �U���p�x�i1�b������̍U���񐔁j
    public float attackRange = 1f; // �U���͈�
    public bool IsSize = true;


    [SerializeField] TMP_Text HpTextMesh; // HP��\������TextMesh
    public RectTransform Texttransform;

    private float lastAttackTime; // �O��̍U������

    private void Start()
    {
        lastAttackTime = Time.time;
        currentHP = maxHP; // ���݂�HP���ő�HP�ŏ�����

        // HP��\������TextMesh���ݒ肳��Ă���ꍇ�AHP���X�V����

        //if (UnitNameTextMesh != null)
        //{
        //    UnitNameText();
        //}


        UpdateScale(); // �����X�P�[���̐ݒ�
                       // GetComponentInChildren<TextMeshPro>
    }

    private void Update()
    {
        if (HpTextMesh != null)
        {
            UpdateHPText();
        }
        if (CanAttack())
        {
            Attack();
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Tanegashima1" && team == "b")
        {
            currentHP -= 50;
            Debug.Log($"{unitName} ���͓S�C�U�����󂯂��I �c��̕��͂�{currentHP}�l");
            UpdateScale(); // �X�P�[�����X�V
            if (currentHP <= 0)
            {
                Die();
            }
        }
        if (c.gameObject.tag == "Tanegashima2" && team == "a")
        {
            currentHP -= 50;
            Debug.Log($"{unitName} ���͓S�C�U�����󂯂��I �c��̕��͂�{currentHP}�l");
            UpdateScale(); // �X�P�[�����X�V
            if (currentHP <= 0)
            {
                Die();
            }
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
                //Debug.Log($"{gameObject.name} attacked {collider.gameObject.name} with {damage} damage. Current HP: {collider.gameObject.GetComponent<Unit>().GetCurrentHP()}");
                Debug.Log($"{unitName}���̍U����{damage}�̑��Q��^�����B�G�̎c��̕��͂�{collider.gameObject.GetComponent<Unit>().GetCurrentHP()}�l");
                // HP��\������TextMesh���ݒ肳��Ă���ꍇ�AHP���X�V����
                if (collider.gameObject.GetComponent<Unit>().HpTextMesh != null)
                {
                    collider.gameObject.GetComponent<Unit>().UpdateHPText();
                }
            }
        }
        lastAttackTime = Time.time;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }

        // HP��\������TextMesh���ݒ肳��Ă���ꍇ�AHP���X�V����
        if (HpTextMesh != null)
        {
            UpdateHPText();
        }

        UpdateScale(); // �X�P�[�����X�V
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    private void Die()
    {
        Debug.Log($"{unitName} ���͑S�ł����I");
        Destroy(gameObject);
    }

    // HP��\������TextMesh���X�V����
    private void UpdateHPText()
    {
        HpTextMesh.text = $"{unitName}��\n����:{currentHP}";
        Texttransform.rotation = Quaternion.Euler(Texttransform.rotation.x, Texttransform.rotation.y, transform.rotation.z * -1);

        //UnitNameTextMesh.text = $" {unitName}��";
        //Texttransform2.rotation = Quaternion.Euler(Texttransform2.rotation.x, Texttransform2.rotation.y, transform.rotation.z * -1);
    }

    private void UnitNameText()
    {
    }

    // HP�ɉ����ăX�P�[����ύX����
    private void UpdateScale()
    {
        Vector3 newScale = transform.localScale;
        if (IsSize == true)
        {
            if (currentHP >= 10000)
            {
                newScale = new Vector3(0.6f, 0.6f, 1f);
            }
            else if (currentHP >= 8000)
            {
                newScale = new Vector3(0.5f, 0.5f, 1f);
            }
            else if(currentHP >= 7000)
            {
                newScale = new Vector3(0.45f, 0.45f, 1f);
            }
            else if (currentHP >= 6000)
            {
                newScale = new Vector3(0.4f, 0.4f, 1f);
            }
            else if (currentHP >= 5000)
            {
                newScale = new Vector3(0.3f, 0.3f, 1f);
            }
            else if (currentHP >= 3000)
            {
                newScale = new Vector3(0.25f, 0.25f, 1f);
            }
            else if (currentHP >= 2000)
            {
                newScale = new Vector3(0.2f, 0.2f, 1f);
            }
            else if (currentHP >= 1000)
            {
                newScale = new Vector3(0.19f, 0.19f, 1f);
            }
            else if (currentHP >= 500)
            {
                newScale = new Vector3(0.18f, 0.18f, 1f);
            }
            else
            {
                newScale = new Vector3(0.17f, 0.17f, 1f);
            }

            transform.localScale = newScale;
        }


    }
}