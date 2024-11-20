using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fighter : MonoBehaviour
{
    private Animator anim;
    private List<GameObject> hitboxes = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        hitboxes.Add(GameObject.Find("LHitbox"));
        hitboxes.Add(GameObject.Find("RHitbox"));
        SetHitboxes(false);
        anim = GetComponent<Animator>();
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
            SetHitboxes(true);
            anim.SetBool("Hit 1",true);
            StartCoroutine(ResetHit(getAnimationLength(5),"Hit 1"));
            
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Hit 1"))
        {
            SetHitboxes(true);
            anim.SetBool("Hit 2",true);
            StartCoroutine(ResetHit(getAnimationLength(6),"Hit 2"));
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Hit 2"))
        {
            SetHitboxes(true);
            anim.SetBool("Hit 3", true);
            StartCoroutine(ResetHit(getAnimationLength(7),"Hit 3"));
        }
    }

    private IEnumerator ResetHit(float time, string hit)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool(hit, false);
        SetHitboxes(false);
    }

    public void AddHitbox(GameObject hitbox)
    {
        hitbox.SetActive(false);
        hitboxes.Add(hitbox);
    }

    void SetHitboxes(bool active)
    {
        foreach(GameObject hitbox in hitboxes)
        {
            hitbox.SetActive(active);
        }
    }

    public void ClearHitboxes()
    {
        int count = hitboxes.Count;
        for(int i = 0; i < count; i++)
        {
            hitboxes.RemoveAt(0);
        }
    }
}
