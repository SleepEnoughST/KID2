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
    [Header("檢查地板尺寸與位移"), Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canJumpLayer;
    
    private Rigidbody2D rb2D;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 20, 0.5f);
        Gizmos.DrawSphere(transform.position + transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Flip();
    }

    public void Move()
    {
        float M = Input.GetAxis("Horizontal");
        print("玩家左右按鍵值:" + M);

        rb2D.velocity = new Vector2(M * speed, rb2D.velocity.y);
    }
    private void Flip()
    {
        float M = Input.GetAxis("Horizontal");

        if(M < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (M > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    #endregion
}
