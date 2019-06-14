using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCtrl : MonoBehaviour
{
    public BoxCollider2D stand;
    public BoxCollider2D crouch;
    public CircleCollider2D circle;

    public BoxCollider2D standShield;
    public BoxCollider2D crouchShield;

    wadCtrl playerC;

    void Start()
    {
        playerC = GetComponent<wadCtrl>();
        stand.enabled = true;
        crouch.enabled = false;
        circle.enabled = true;
        standShield.enabled = false;
        crouchShield.enabled = false;

    }

    void Update()
    {
        if (playerC.isOnGround == false)
        {
            stand.enabled = true;
            crouch.enabled = false;
            circle.enabled = false;
            if (playerC.shield == true)
            {
                crouchShield.enabled = false;
                standShield.enabled = true;
            }
            else
            {
                crouchShield.enabled = false;
                standShield.enabled = false;
            }
        }
        else
        {
            if(playerC.crouching == true)
            {
                stand.enabled = false;
                crouch.enabled = true;
                circle.enabled = true;
                if (playerC.shield == true)
                {
                    crouchShield.enabled = true;
                    standShield.enabled = false;
                }
                else
                {
                    crouchShield.enabled = false;
                    standShield.enabled = false;
                }
            }
            else
            {
                stand.enabled = true;
                crouch.enabled = false;
                circle.enabled = true;
                if (playerC.shield == true)
                {
                    crouchShield.enabled = false;
                    standShield.enabled = true;
                }
                else
                {
                    crouchShield.enabled = false;
                    standShield.enabled = false;
                }
            }
        }
    }
}
