using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public Image gameOverPanel;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public bool isGameOver = false;

    private void Update()
    {
        /*if (player1.GetComponent<PlayerHealth>().CheckIfDown() && player2.GetComponent<PlayerHealth>().CheckIfDown() && player3.GetComponent<PlayerHealth>().CheckIfDown() && !isGameOver)
        {
            ShowGameOver();
        }*/
        if (player1.GetComponent<PlayerHealth>().CheckIfDown() && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(GameOverFadeIn());
            LockControls();
            DisplayButtons();
        }
    }
    private void ShowGameOver()
    {
        Color color = gameOverPanel.color;
        color.a = 1.0f;

        gameOverPanel.color = color;
    }

    private IEnumerator GameOverFadeIn()
    {
        Color color = gameOverPanel.color;
        color.a = 0.0f;

        float currentTime = 0.0f;
        float timeToFadeIn = 3.0f;

        while (currentTime < timeToFadeIn)
        {
            
            yield return new WaitForSeconds(0.1f); 
            color.a += 0.033f;
            gameOverPanel.color = color;
            currentTime += 0.1f;
        }

    }

    private void LockControls()
    {

    }

    private void DisplayButtons()
    {

    }
}
