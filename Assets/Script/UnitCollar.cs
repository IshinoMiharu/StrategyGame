using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCollar : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int collar = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (collar == 1)
        {
            // SpriteRenderer�R���|�[�l���g���擾
            spriteRenderer = GetComponent<SpriteRenderer>();

            // �����̐F��Ԃɐݒ�
            spriteRenderer.color = Color.red;
        }
        else if (collar == 2)
        {            // SpriteRenderer�R���|�[�l���g���擾
            spriteRenderer = GetComponent<SpriteRenderer>();

            // �����̐F��Ԃɐݒ�
            spriteRenderer.color = Color.blue;
        }
        else if (collar == 3)
        {            // SpriteRenderer�R���|�[�l���g���擾
            spriteRenderer = GetComponent<SpriteRenderer>();

            // �����̐F��Ԃɐݒ�
            spriteRenderer.color = Color.green;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
