using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField] float timeToLive = 1.0f;

    private void Update()
    {
        timeToLive -= Time.deltaTime;

        if (timeToLive < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
