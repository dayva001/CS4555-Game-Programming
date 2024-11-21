using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfTheDragon : MonoBehaviour
{

    public bool tomeIsCollected = false;
    public GameObject tomeImage;
    public GameObject elevatorCollider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tomeIsCollected = true;
            gameObject.SetActive(false);
            tomeImage.SetActive(true);
            elevatorCollider.SetActive(true);
        }
    }
}
