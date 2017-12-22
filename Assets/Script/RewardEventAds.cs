using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RewardEventAds : MonoBehaviour {

    private Animation anim;
    public AnimationClip _in, _out;

    public static RewardEventAds instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        anim = GetComponent<Animation>();
    }

    public void Occur(){
        anim.clip = _in;
        anim.Play();
        SoundManager.instance.Alert();

    }

    public void Hide(){
        anim.clip = _out;
        anim.Play();
        // Init;
    }
}
