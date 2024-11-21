using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public int damageAmount;
    public bool isPlayerDamage = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && isPlayerDamage)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            
        }
        else if (collision.gameObject.tag == "Player" && !isPlayerDamage)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
}
