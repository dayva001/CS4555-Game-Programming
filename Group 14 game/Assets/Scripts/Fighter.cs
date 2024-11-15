using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnClick();
        }
    }
    
    void OnClick()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            anim.SetBool("Hit 1",true);
            StartCoroutine(ResetHit(anim.GetCurrentAnimatorStateInfo(0).length,"Hit 1"));
            
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Hit 1"))
        {
            anim.SetBool("Hit 2",true);
            StartCoroutine(ResetHit(anim.GetCurrentAnimatorStateInfo(0).length,"Hit 2"));
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Hit 2"))
        {
            anim.SetBool("Hit 3", true);
            StartCoroutine(ResetHit(anim.GetCurrentAnimatorStateInfo(0).length,"Hit 3"));
        }
    }

    private IEnumerator ResetHit(float time, string hit)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool(hit, false);
    }
}
