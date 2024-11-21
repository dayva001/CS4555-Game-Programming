using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public Image gameOverPanel;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public bool isGameOver = false;

    public GameObject titleScreenButton;
    public GameObject quitGameButton;

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
        // All controls except movement should be locked when isDown is true.
        // Need to lock movement.
    }

    private void DisplayButtons()
    {
        titleScreenButton.SetActive(true);
        quitGameButton.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("QUITTING THE GAME");
        Application.Quit();
    }

    public void ToTitleScreen()
    {
        Debug.Log("GO BACK TO TITLE SCREEN");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
