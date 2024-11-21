using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class RangerAttacks : MonoBehaviour
{
    private Animator anim;
    public GameObject projectile;
    public GameObject castPoint;
    GameObject arrow;
    bool crRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void OnAttack(InputAction.CallbackContext context)
    {
        OnClick();

    }

    float getAnimationLength(int index)
    {
        return anim.runtimeAnimatorController.animationClips[index].length;
    }

    void OnClick()
    {
        if (!crRunning)
        {
            if ((anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Run")))
            {
                anim.SetTrigger("Shoot");
                StartCoroutine(FireArrow(getAnimationLength(5)));
            }
        }
    }
    private IEnumerator FireArrow(float time)
    {
        crRunning = true;
        yield return new WaitForSeconds(time);
        if(arrow != null)
        {
            Destroy(arrow);
        }
        arrow = Instantiate(projectile, castPoint.transform.position, gameObject.transform.rotation);
        crRunning = false;
    }
}
