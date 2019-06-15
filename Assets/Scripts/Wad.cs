using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Wad : MonoBehaviour
{
    public Image damageScreen;
    public Color imageColor;
    private Color fadeColor = new Color(161f, 2f, 2f, 0f);

    public float fadeSpeed;
    private bool isHurt = false;

    public wadStats playerStats = new wadStats();

    public int arrowDamage;
    public GameObject prefab;

    wadCtrl playerC;

    Rigidbody2D rb;
    public float forceY;

    public int spikeDmg;
    float time = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if (transform.position.y > other.transform.position.y + 1)
            {
                transform.SetParent(other.transform);
            }
        }
        if (other.gameObject.CompareTag("Arrow"))
        {
            DamagePlayer(arrowDamage);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Spike"))
        {
            if (time < Time.time)
            {
                rb.velocity = new Vector2(0, 0);
                Vector2 pushBack = new Vector2(0, forceY);
                rb.AddForce(pushBack, ForceMode2D.Impulse);
                DamagePlayer(spikeDmg);
                time = Time.time + 0.2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            if(playerStats.Health < playerStats.maxHP)
            {
                playerStats.Health += 1;
                other.gameObject.SetActive(false);
            }
            else
            {
                return;
            }
        }
        if(other.gameObject.CompareTag("Shield"))
        {
            playerStats.SetShield();
        }
        if (other.gameObject.CompareTag("Arrow"))
        {
            DamageWithShield(arrowDamage);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }

    private void Awake()
    {
        if (damageScreen == null)
        {
            damageScreen = GameObject.FindGameObjectWithTag("Damage").GetComponent<Image>();
        }
        playerC = GetComponent<wadCtrl>();
    }

    void Start()
    {
        playerStats.SetHealth();
        playerStats.Shield = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isHurt == true)
        {
            damageScreen.color = imageColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, fadeColor, fadeSpeed * Time.deltaTime);
        }
        isHurt = false;
    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        isHurt = true;
        Debug.Log("HIT");

        if (playerStats.Health <= 0)
        {
            Destroy(gameObject);
            GameMng.GM.StartCoroutine(GameMng.GM.Respawn());
        }
    }

    public void DamageWithShield(int damage)
    {
        int helpShield = playerStats.Shield;
        playerStats.Shield -= damage;
        if(playerStats.Shield < 0)
        {
            playerC.shield = false;
            playerStats.Health -= damage - helpShield;
            if(playerStats.Health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if(playerStats.Shield == 0)
        {
            playerC.shield = false;
        }
        else
        {
            Debug.Log("FULL SHIELD");
        }
    }
}
