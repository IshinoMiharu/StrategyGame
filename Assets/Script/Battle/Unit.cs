using TMPro;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName; //部隊の名前
    public string team;         // 陣営の名前
    public int maxHP = 10000;     // 最大HP
    public int currentHP;      // 現在のHP

    public int minAttackDamage = 10; // 最小攻撃ダメージ
    public int maxAttackDamage = 20; // 最大攻撃ダメージ
    public float attackFrequency = 1f; // 攻撃頻度（1秒あたりの攻撃回数）
    public float attackRange = 1f; // 攻撃範囲
    public bool IsSize = true;


    [SerializeField] TMP_Text HpTextMesh; // HPを表示するTextMesh
    public RectTransform Texttransform;

    private float lastAttackTime; // 前回の攻撃時刻

    private void Start()
    {
        lastAttackTime = Time.time;
        currentHP = maxHP; // 現在のHPを最大HPで初期化

        // HPを表示するTextMeshが設定されている場合、HPを更新する

        //if (UnitNameTextMesh != null)
        //{
        //    UnitNameText();
        //}


        UpdateScale(); // 初期スケールの設定
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
            Debug.Log($"{unitName} 隊は鉄砲攻撃を受けた！ 残りの兵力は{currentHP}人");
            UpdateScale(); // スケールを更新
            if (currentHP <= 0)
            {
                Die();
            }
        }
        if (c.gameObject.tag == "Tanegashima2" && team == "a")
        {
            currentHP -= 50;
            Debug.Log($"{unitName} 隊は鉄砲攻撃を受けた！ 残りの兵力は{currentHP}人");
            UpdateScale(); // スケールを更新
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
                int damage = Random.Range(minAttackDamage, maxAttackDamage + 1); // minAttackDamage以上maxAttackDamage以下の乱数を生成
                collider.gameObject.GetComponent<Unit>().TakeDamage(damage);
                //Debug.Log($"{gameObject.name} attacked {collider.gameObject.name} with {damage} damage. Current HP: {collider.gameObject.GetComponent<Unit>().GetCurrentHP()}");
                Debug.Log($"{unitName}隊の攻撃で{damage}の損害を与えた。敵の残りの兵力は{collider.gameObject.GetComponent<Unit>().GetCurrentHP()}人");
                // HPを表示するTextMeshが設定されている場合、HPを更新する
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

        // HPを表示するTextMeshが設定されている場合、HPを更新する
        if (HpTextMesh != null)
        {
            UpdateHPText();
        }

        UpdateScale(); // スケールを更新
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    private void Die()
    {
        Debug.Log($"{unitName} 隊は全滅した！");
        Destroy(gameObject);
    }

    // HPを表示するTextMeshを更新する
    private void UpdateHPText()
    {
        HpTextMesh.text = $"{unitName}隊\n兵数:{currentHP}";
        Texttransform.rotation = Quaternion.Euler(Texttransform.rotation.x, Texttransform.rotation.y, transform.rotation.z * -1);

        //UnitNameTextMesh.text = $" {unitName}隊";
        //Texttransform2.rotation = Quaternion.Euler(Texttransform2.rotation.x, Texttransform2.rotation.y, transform.rotation.z * -1);
    }

    private void UnitNameText()
    {
    }

    // HPに応じてスケールを変更する
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