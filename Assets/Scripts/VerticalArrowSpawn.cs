using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalArrowSpawn : MonoBehaviour
{
    public VArrowScript arrowPrefab;
    public float arrowSpeed;
    private float time = 0;
    public float arrowDelay;

    public bool fromAbove = false;
    public bool shoot;

    private Vector2 dir2;

    void Start()
    {
        dir2 = new Vector2(arrowSpeed, -360);
    }

    void Update()
    {
        if (shoot == true)
        {
            if (time < Time.time)
            {
                VArrowScript arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as VArrowScript;
                arrow.dir = dir2;
                if (fromAbove == true)
                {
                    arrow.transform.rotation = Quaternion.Euler(-45, -90, 90);
                }
                time = Time.time + arrowDelay;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shoot = false;
        }
    }
}