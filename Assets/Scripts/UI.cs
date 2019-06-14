using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image heart;
    public Sprite[] heartSprite;

    public Image shieldImg;
    public Sprite[] shieldSprite;

    Wad player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Wad>();
    }

    void Update()
    {
        if (player != null)
        {
            ChangingUIHealth();
            ChangingUIShield();
        }
        else
        {
            player = FindObjectOfType<Wad>();
            heart.enabled = false;
            shieldImg.enabled = false;
        }
    }

    void ChangingUIHealth()
    {
        if (player.playerStats.Health > 0)
        {
            heart.enabled = true;
            heart.sprite = heartSprite[player.playerStats.Health - 1];
        }
    }

    void ChangingUIShield()
    {
        if (player.playerStats.Shield > 0)
        {
            shieldImg.enabled = true;
            shieldImg.sprite = heartSprite[player.playerStats.Shield - 1];
        }
        else
        {
            shieldImg.enabled = false;
        }
    }
}
