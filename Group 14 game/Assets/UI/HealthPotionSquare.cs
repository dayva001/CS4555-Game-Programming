using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotionSquare : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

   /* private IEnumerator StartCooldownTimer(float cooldownTime)
    {
        float currentTime = 0f;

        while (currentTime < cooldownTime)
        {
            currentTime += Time.deltaTime;

            slider.value = cooldownTime - currentTime; // Update slider value based on timer progress

            yield return new WaitForSeconds(1.5f); // Wait for the next frame
        }

        fill.color = gradient.Evaluate(1f);
    }

    public void StartCooldown(float cooldownTime)
    {
        fill.color = gradient.Evaluate(0f);
        StartCoroutine(StartCooldownTimer(cooldownTime)); // Start the timer coroutine
    }*/

}
