using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MageAttacks : MonoBehaviour
{
    private Animator anim;
    public ParticleSystem hitParticles;


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
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            anim.SetBool("Hit 1",true);
            Instantiate(hitParticles, transform.position, Quaternion.identity);
            StartCoroutine(ResetHit(getAnimationLength(5),"Hit 1"));
            
        }
    }

    private IEnumerator ResetHit(float time, string hit)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool(hit, false);
    }
}