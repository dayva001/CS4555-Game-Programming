using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    private bool canTakeDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if(canTakeDamage)
        {
            print("Hit " + this.name + " for " + damage + " damage.");
            currentHealth -= damage;
            canTakeDamage = false;
            if (currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
            StartCoroutine(DamageCooldown(0.1f));
        }
    }

    private IEnumerator DamageCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        canTakeDamage = true;
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
