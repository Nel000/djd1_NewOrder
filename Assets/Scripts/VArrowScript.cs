using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VArrowScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 dir = new Vector2(0, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = dir;
    }
}
