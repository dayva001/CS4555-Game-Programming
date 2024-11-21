using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    private bool canTakeDamage = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if(canTakeDamage)
        {
            currentHealth -= damage;
            canTakeDamage = false;
            if (currentHealth <= 0)
            {
                Die();
            }
            StartCoroutine(DamageCooldown(0.1f));
        }
    }
    private void Die()
    {
        animator.SetBool("isDead", true);
        animator.Play("Death");
        StartCoroutine(DestroyEnemy(getAnimationLength("Death")+0.3f));
    }
    private IEnumerator DestroyEnemy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    private float getAnimationLength(string name)
    {
        for(int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            if (animator.runtimeAnimatorController.animationClips[i].name == name)
            {
                return animator.runtimeAnimatorController.animationClips[i].length;
            }
        }
        return 0;
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
