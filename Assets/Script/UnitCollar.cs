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
            // SpriteRendererコンポーネントを取得
            spriteRenderer = GetComponent<SpriteRenderer>();

            // 初期の色を赤に設定
            spriteRenderer.color = Color.red;
        }
        else if (collar == 2)
        {            // SpriteRendererコンポーネントを取得
            spriteRenderer = GetComponent<SpriteRenderer>();

            // 初期の色を赤に設定
            spriteRenderer.color = Color.blue;
        }
        else if (collar == 3)
        {            // SpriteRendererコンポーネントを取得
            spriteRenderer = GetComponent<SpriteRenderer>();

            // 初期の色を赤に設定
            spriteRenderer.color = Color.green;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
