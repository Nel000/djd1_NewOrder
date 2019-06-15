using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wadAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public LayerMask whatIsEnemies;
    public Transform attackPos;
    public float attackRange;
    public int damage;
    Animator anim;

    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Z))
            {
                //anim.setTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<MonsterCtrl>().TakeDamage(damage);
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
