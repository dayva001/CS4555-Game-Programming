using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ProBuilder.AutoUnwrapSettings;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public HealthPotionSquare healthPotionSquare;
    public bool canHeal = true;
    public RageScrollSquare rageScrollSquare;
    public bool canRage = true;
    public bool isRaged = false;
    // Any keyboard input should be blocked if player is down. Movement is fractioned.
    public bool isDown = false;
    public bool canTakeDamage = true;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Z) && canHeal && !isDown)
        {
            Heal();
        }
        if (Input.GetKeyDown(KeyCode.B) && canRage && !isDown)
        {
            Rage();
        }*/

        if (currentHealth <= 0)
        {
            isDown = true;
            gameObject.tag = "Downed";
            gameObject.GetComponent<BoxCollider>().enabled = true;
            healthBar.SetHealth(0);
        }
    }

    public void OnHeal(InputAction.CallbackContext context)
    {
        if (!isDown)
        {
            Heal();
        }
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        if(!isDown)
        {
            Rage();
        }
    }

    public void TakeDamage(int damage)
    {
        if(!canTakeDamage)
        {
            return;
        }
        if (isRaged)
        {
            damage = damage / 2;
        }
        currentHealth -= damage;
        animator.SetTrigger("Take Damage");

        healthBar.SetHealth(currentHealth);
        StartCoroutine(StopDamage(0.3f));
    }
    private IEnumerator StopDamage(float time)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(time);
        canTakeDamage = true;
    }
    void Heal()
    {
        // When healing, the players health will become full, the player cannot heal, the slider value should be zero, and the item square should be red.
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
        canHeal = false;
        healthPotionSquare.slider.value = 0;
        healthPotionSquare.fill.color = healthPotionSquare.gradient.Evaluate(0f);
        StartCoroutine(StartHealthCooldownTimer());
    }

    // Cooldown for health.
    private IEnumerator StartHealthCooldownTimer()
    {
        float currentTime = 0.0f;
        float cooldownTime = 30.0f; // Change health cooldown time here (in seconds).

        while (currentTime < cooldownTime)
        {
            healthPotionSquare.slider.value = currentTime;

            yield return new WaitForSeconds(1.0f); // Wait one second and update the current time by one.
            currentTime += 1f;
        }

        // Once the cooldown time is up, slider value should be max, item square should be green, and player should be able to heal.
        healthPotionSquare.slider.value = healthPotionSquare.slider.maxValue;
        healthPotionSquare.fill.color = healthPotionSquare.gradient.Evaluate(1f);
        canHeal = true;
    }

    // Rage reduces the damage the player takes and increases the damage they inflict.
    void Rage() 
    {
        canRage = false;
        isRaged = true;
        rageScrollSquare.slider.value = 0;
        rageScrollSquare.fill.color = rageScrollSquare.gradient.Evaluate(0f);
        StartCoroutine(StartRageCooldownTimer());
    }
    // Cooldown for rage.
    private IEnumerator StartRageCooldownTimer()
    {
        float currentTime = 0.0f;
        float cooldownTime = 60.0f; // Change rage cooldown time here (in seconds).

        while (currentTime < cooldownTime)
        {
            rageScrollSquare.slider.value = currentTime;

            yield return new WaitForSeconds(1.0f); // Wait one second and update the current time by one.
            currentTime += 1f;

            // Rage will wear off sooner than the player can use rage again.
            if (currentTime == 20.0f) // Change here.
            {
                isRaged = false;
            }
        }

        // Once the cooldown time is up, slider value should be max, item square should be green, and player should be able to rage.
        rageScrollSquare.slider.value = rageScrollSquare.slider.maxValue;
        rageScrollSquare.fill.color = rageScrollSquare.gradient.Evaluate(1f);
        canRage = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isDown)
        {
            // Stops the reviving player (collision object) from having the Revived() function ran on it.
            gameObject.GetComponent<PlayerHealth>().Revived();
        }
    }

    public bool CheckIfDown()
    {
        return isDown;
    }

    public void Revived()
    {
        isDown = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        currentHealth = maxHealth / 2;
        healthBar.SetHealth(currentHealth);
        // Note: See Move() function in PlayerController script to understand down-revive cyrcle.
    }
}
