using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    #region ���
    [Header("�ˬd�l�ܰϰ�j�p�P�첾")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("���ʳt��")]
    public float speed = 1.5f;
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;
    [Header("�ʵe�Ѽ�")]
    public string enemyWalk = "������";
    [Header("���V�ؼЪ���")]
    public Transform target;

    private float angle = 0;
    private Rigidbody2D rb;
    private Animator anim;
    #endregion

    #region �ƥ�
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        //���w�ϥܪ��C��
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //ø�s�ߤ���(���ߡA�ؤo)
        Gizmos.DrawCube(transform.position +transform.TransformDirection(v3TrackOffset), v3TrackSize);
    }

    private void Update()
    {
        CheckTargetInArea();
    }
    #endregion

    #region ��k
    /// <summary>
    /// �ˬd�ؼЬO�_�b�ϰ줺
    /// </summary>
    private void CheckTargetInArea()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit)
        {
            Move();
        }
        else
        {
            anim.SetBool(enemyWalk, false);
        }
    }
    private void Move()
    {
        //�p�G �ؼЪ� X �p�� �ĤH�� X �N�N��b���� ���� 0
        //�p�G �ؼЪ� X �j�� �ĤH�� X �N�N��b�k�� ���� 180
        if (target.position.x > transform.position.x)
        {
            // �k�� angle = 180
        }
        else if (target.position.x < transform.position.x)
        {
            // ���� angle = 0
        }

        //�T���B��l�y�k�G���L�� ? (���L�� �� true) : (���L�� �� false) ;
        angle = target.position.x > transform.position.x ? 180 : 0;

        transform.eulerAngles = Vector3.up * angle;

        rb.velocity =transform.TransformDirection( new Vector2(-speed, rb.velocity.y));
        anim.SetBool(enemyWalk, true);
    }
    #endregion
}
