using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wadStats 
{
    public int health;
    public int shield;

    public int maxHP = 5;
    public int maxShield = 2;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = Mathf.Clamp(value, 0, maxHP);
        }
    }

    public int Shield
    {
        get
        {
            return shield;
        }
        set
        {
            shield = Mathf.Clamp(value, -100, maxShield);
        }
    }

    public void SetHealth()
    {
        Health = maxHP;
    }

    public void SetShield()
    {
        Shield = maxShield;
    }
}
