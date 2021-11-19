using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 課程 : MonoBehaviour
{
    #region 欄位:公開
    [Header("移動速度"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float jump = 300;
    
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float M = Input.GetAxis("Horizontal");
        print("玩家左右按鍵值:" + M);
    }
    #endregion
}
