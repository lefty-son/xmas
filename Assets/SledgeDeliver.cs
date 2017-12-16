using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledgeDeliver : MonoBehaviour {

    private Animation anim;

    public AnimationClip deliver, comeback;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    public void Deliver(){
        UIManager.instance.tap.interactable = false; 
        SledgeUIHolder.instance.HideAndInitCounter();
        anim.clip = deliver;
        anim.Play();
    }

    public void Comeback(){
        BoxInSledge.instance.Init();
        anim.clip = comeback;
        anim.Play();
    }

    // Do all things when come back;
    public void EnableButtons(){
        SledgeUIHolder.instance.Dollar();
        UIManager.instance.EnableButtons();
    }
}
