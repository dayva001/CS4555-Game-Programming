using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fighter : MonoBehaviour
{
    private Animator anim;
    private Controls actions;
    private InputAction attack;
    

    void Awake()
    {
        actions = new Controls();
        attack = actions.PlayerControls.Attack;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attack.triggered)
        {
            OnClick();
        }
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
    void OnEnable()
    {
        actions.PlayerControls.Enable();
    }
    void OnDisable()
    {
        actions.PlayerControls.Disable();
    }
}
