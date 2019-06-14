using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    AudioSource source;
    wadCtrl playerC;

    private void Start()
    {
        playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<wadCtrl>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            source.Play();
            playerC.shield = true;
            Destroy(gameObject);
        }
    }
}
