using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ProBuilder.AutoUnwrapSettings;
using UnityEngine.UIElements;
using Unity.VisualScripting;

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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && canHeal && !isDown)
        {
            Heal();
        }
        if (Input.GetKeyDown(KeyCode.B) && canRage && !isDown)
        {
            Rage();
        }

        if (currentHealth <= 0)
        {
            isDown = true;
            gameObject.tag = "Downed";
        }
        if (Input.GetKeyDown(KeyCode.L)) // Temporary for testing.
        {
            Revived();
        }
    }

    public void TakeDamage(int damage)
    {
        if (isRaged)
        {
            damage = damage / 2;
        }
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
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

    public bool CheckIfDown()
    {
        return isDown;
    }

    public void Revived()
    {
        isDown = false;
        currentHealth = maxHealth / 2;
        healthBar.SetHealth(currentHealth);
        // Note: See Move() function in PlayerController script to understand down-revive cyrcle.
    }
}
