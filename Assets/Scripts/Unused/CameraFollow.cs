using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

    private float pX;
    private float pY;

    private Vector2 currentVelocity;

    public float smoothX;
    public float smoothY;

    public bool border;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            SmoothCamera();
        }
        if (border == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);

        }
    }

    void SmoothCamera()
    {
        pX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref currentVelocity.x, smoothX);
        pY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref currentVelocity.y, smoothY);
        transform.position = new Vector3(pX, pY, transform.position.z);
    }
}
