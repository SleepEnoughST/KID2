using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 角色 : MonoBehaviour
{
    public float MovementSpeed = 10;
    public float JumpForce = 15;
    public Animator animator;
    public Animator anim;
    private Rigidbody2D _rigidbody;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    public void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, -180, 0) : Quaternion.identity;

        animator.SetFloat("走路", Mathf.Abs(movement));



        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("跳躍", true);
        }
        if (_rigidbody.velocity.y == 0)
        {
            anim.SetBool("跳躍", false);
        }
        if (_rigidbody.velocity.y > 0)
        {
            anim.SetBool("跳躍", true);
        }
        if (_rigidbody.velocity.y < 0)
        {
            anim.SetBool("跳躍", true);
        }
    }


}
