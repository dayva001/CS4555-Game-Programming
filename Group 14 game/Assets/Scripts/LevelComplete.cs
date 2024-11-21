using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2; 
    public GameObject player3;
/*    private int playersInElevator;
*/    public GameObject levelCompleteScreen;

    /*private void Update()
    {
        if (playersInElevator == 3 )
        {
            StartCoroutine(LevelCompleteScreenFadeIn());
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*playersInElevator += 1;*/
            EnableLevelCompleteScreen();
        }
    }
    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playersInElevator -= 1;
        }
    }*/

    private void EnableLevelCompleteScreen()
    {
        levelCompleteScreen.SetActive(true);
    }
}
