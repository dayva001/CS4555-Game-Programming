using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    // Enemies take damage depending on what player weapon hits them.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerMageProjectile")
        {
            TakeDamage(20);
        }
        if (collision.gameObject.tag == "PlayerArcherProjectile")
        {
            TakeDamage(10);
        }
        if (collision.gameObject.tag == "PlayerMeleeWeapon")
        {
            TakeDamage(30);
        }
    }
}
