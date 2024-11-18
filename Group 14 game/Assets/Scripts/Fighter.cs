using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fighter : MonoBehaviour
{
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        for(int i=0; i<anim.runtimeAnimatorController.animationClips.Length; i++)
        {
            Debug.Log(anim.runtimeAnimatorController.animationClips[i].name + " " + anim.runtimeAnimatorController.animationClips[i].length);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
            StartCoroutine(ResetHit(getAnimationLength(5),"Hit 1"));
            
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Hit 1"))
        {
            anim.SetBool("Hit 2",true);
            StartCoroutine(ResetHit(getAnimationLength(6),"Hit 2"));
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Hit 2"))
        {
            anim.SetBool("Hit 3", true);
            StartCoroutine(ResetHit(getAnimationLength(7),"Hit 3"));
        }
    }

    private IEnumerator ResetHit(float time, string hit)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool(hit, false);
    }
}
