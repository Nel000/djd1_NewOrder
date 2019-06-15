using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public Transform originPoint, originPoint2;
    private Vector2 dir = new Vector2(-1, 0);
    public float range;
    public float speed;

    public int health;
    //float dazedTime;
    //public float startDazedTime;

    Rigidbody2D rb;
    public GameObject bloodEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.DrawRay(originPoint.position, dir * range);
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, dir, range);
        RaycastHit2D hit2 = Physics2D.Raycast(originPoint2.position, dir, range);
        if (hit2 == true)
        {
            if(hit.collider.CompareTag("Ground"))
            {
                Flip();
                speed *= -1;
                dir *= -1;
            }
        }
        if (hit == false || hit.collider.CompareTag("Player"))
        {
            Flip();
            speed *= -1;
            dir *= -1;
        }

        /*if (dazedTime <= 0)
        {
            speed = -75;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }*/

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void TakeDamage (int damage)
    {
        //dazedTime = startDazedTime;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("HIT");
    }
}
