using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wadCtrl : MonoBehaviour
{
    Rigidbody2D rB;
    public Animator anim;

    public float hMove;
    public float speed = 5.5f;
    public float jump;
    public float jumpForce;

    public bool isOnGround;
    public bool facingRight = true;

    public LayerMask whatIsGround;
    public float groundRadius;
    public Transform groundPoint;
    public Transform ceilPoint;

    private bool ceiled;
    private float crouch;
    public bool crouching;

    public bool shield = false;

    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Jump");
        crouch = Input.GetAxisRaw("CrouchInput");

        CrouchFunction();

        AnimationControl();
    }

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, groundRadius, whatIsGround);
        ceiled = Physics2D.OverlapCircle(ceilPoint.position, groundRadius, whatIsGround);

        Move();
        Jump();
        Flip();

        anim.SetBool("Crouch", crouching);
        anim.SetFloat("Speed", Mathf.Abs(rB.velocity.x));
        anim.SetBool("isOnGround", isOnGround);
        anim.SetFloat("vSpeed", rB.velocity.y);
    }

    void Move()
    {
        rB.velocity = new Vector2(hMove * speed, rB.velocity.y);
    }

    void Jump()
    {
        if(isOnGround)
        {
            rB.velocity = new Vector2(rB.velocity.x, jump * jumpForce);
        }
    }

    void Flip()
    {
        if ((hMove < 0 && facingRight == true) || (hMove > 0 && facingRight == false))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }

    void CrouchFunction()
    {
        if((crouch != 0 || ceiled == true) && isOnGround == true)
        {
            crouching = true;
        }
        else
        {
            crouching = false;
        }
    }

    void AnimationControl()
    {
        if (shield == false)
        {
            anim.SetLayerWeight(1, 0);
        }
        else
        {
            anim.SetLayerWeight(1, 1);
        }
    }

}
