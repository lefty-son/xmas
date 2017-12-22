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
        if (GameManager.instance.IsRewardFever)
        {
            anim[deliver.name].speed = PrefManager.instance.GetSledSpeedCalc() * 2;
        }
        else
        {
            anim[deliver.name].speed = PrefManager.instance.GetSledSpeedCalc();

        }
        anim.Play();
        SoundManager.instance.Drag();
    }

    public void Comeback(){
        BoxInSledge.instance.Init();
        anim.clip = comeback;
        if (GameManager.instance.IsRewardFever)
        {
            anim[comeback.name].speed = PrefManager.instance.GetSledSpeedCalc() * 2;
        }
        else
        {
            anim[comeback.name].speed = PrefManager.instance.GetSledSpeedCalc();

        }
        anim.Play();
        SoundManager.instance.Drag();
    }

    // Do all things when come back;
    public void EnableButtons(){
        SledgeUIHolder.instance.Dollar();
        UIManager.instance.EnableButtons();
    }
}
