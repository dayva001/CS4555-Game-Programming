using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public bool playerDamage = true;
    public int damage = 5;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !playerDamage)
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        else if (other.gameObject.tag == "Enemy" && playerDamage)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}