using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MageAttacks : MonoBehaviour
{
    private Animator anim;
    public ParticleSystem hitParticles;
    public GameObject castPoint;


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
            gameObject.GetComponent<Player1Controller>().canMove = false;
            StartCoroutine(ShootMagic(1.1f));
            StartCoroutine(ResetHit(getAnimationLength(5),"Hit 1"));
            
        }
    }
    private IEnumerator ShootMagic(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(hitParticles, castPoint.transform.position, transform.rotation);
    }

    private IEnumerator ResetHit(float time, string hit)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool(hit, false);
        gameObject.GetComponent<Player1Controller>().canMove = true;
    }
}