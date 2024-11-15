using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    bool playerInRange = false;
    Collider player = null;
    //adjust this to change how high it goes
    public float height = 1f;
    public float rotateSpeed = 3f;
    private float timeOffset;
    public GameObject pickupUI;
    public GameObject equipment;
    public AnimatorOverrideController newAnimations;
    private bool equipped = false;
    public string scriptName;

    // Start is called before the first frame update
    void Start()
    {
        timeOffset = Random.Range(-1f, 1f);
        pickupUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerInRange && !equipped)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                EquipItem();
            }
        }
    }

     void FixedUpdate()
    {
        Rotate();
    }

    private void EquipItem()
    {
        equipped = true;
        pickupUI.SetActive(false);
        player.gameObject.GetComponent<Animator>().SetTrigger("Grab");
        player.gameObject.GetComponent<Animator>().SetTrigger("Grab");

        GameObject parent = GameObject.Find("WeaponHolder");
        transform.SetParent(parent.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        //Instantiate(equipment, parent.transform);
        player.gameObject.GetComponent<Animator>().runtimeAnimatorController = newAnimations;
        player.gameObject.AddComponent(System.Type.GetType(scriptName));
        //Destroy(this.gameObject.transform.parent.gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        player = other;
        playerInRange = true;
        pickupUI.SetActive(true);
        
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
        playerInRange = false;
        pickupUI.SetActive(false);
    }

    private void Rotate()
    {
        if (!equipped)
        {
            // Rotate the object on X, Y, and Z axes by specified amounts, adjusted for frame rate.
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime * rotateSpeed);
            //get the objects current position and put it in a variable so we can access it later with less code
            Vector3 pos = transform.position;

            //calculate what the new Y position will be
            float newY = pos.y + Mathf.Sin((Time.time + timeOffset)) * (height / 180);
            //set the object's Y to the new calculated Y
            transform.position = new Vector3(pos.x, newY, pos.z);
        }
    }

}

 
