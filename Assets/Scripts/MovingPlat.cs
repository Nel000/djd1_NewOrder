using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public Transform[] point;
    public int startingPoint;
    public int targetPoint;
    public float speed;
    public bool move;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            move = true;
        }
    }

    void Start()
    {
        transform.position = point[startingPoint].position;
    }

    void Update()
    {
        if (move == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, point[targetPoint].position, speed * Time.deltaTime);
            if (transform.position == point[targetPoint].position)
            {
                targetPoint++;
                if (targetPoint == point.Length)
                {
                    targetPoint = 0;
                }
            }
        }       
    }
}
