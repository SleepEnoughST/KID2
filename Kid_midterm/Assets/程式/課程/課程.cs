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
    public string parameterWalk = "角色走路";
    public string parameterJump = "角色跳躍";
    #endregion

    #region 欄位:私人
    private Rigidbody2D rb2D;
    private Animator anim;
    [SerializeField]
    private bool IsGround;
    [SerializeField]
    private int jumpCount;
    [SerializeField]
    private bool jumpPress;
    #endregion

    #region 事件
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 20, 0.5f);
        Gizmos.DrawSphere(transform.position + transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Flip();
        CheckGround();
        Jump();
    }
    #endregion

    #region 方法
    public void Move()
    {
        float M = Input.GetAxis("Horizontal");
        //print("玩家左右按鍵值:" + M);

        rb2D.velocity = new Vector2(M * speed, rb2D.velocity.y);

        anim.SetBool(parameterWalk, M != 0);
    }
    private void Flip()
    {
        float M = Input.GetAxis("Horizontal");

        if (M < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (M > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    private void CheckGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);
        //print("碰到的物件:" + hit.name);
        IsGround = hit;

        anim.SetBool(parameterJump, !IsGround);
    }

    private void Jump()
    {
        
        if (IsGround)
        {
            jumpCount = 0;

            if (Input.GetKeyDown(keyjump) && jumpCount < 2)
            {
                rb2D.AddForce(new Vector2(0, jump));
                jumpCount++;
                jumpPress = true;
            }

            
        }
    }
    #endregion
}
