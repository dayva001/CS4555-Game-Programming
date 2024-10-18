using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    bool playerInRange = false;
    Collider player = null;
    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.gameObject.GetComponent<Animator>().SetTrigger("Grab");
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        player = other;
        playerInRange = true;   
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
        playerInRange = false;
    }
}
