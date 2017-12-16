using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour {
    public static GiftSpawner instance;

    public Animation[] giftAnimation;

    public AnimationClip _in, _out;

    public void NextWave(){
        foreach(Animation anim in giftAnimation){
            anim.transform.localPosition = Vector3.zero;
        }
        ConveyorIn();
    }

    private void Start()
    {
        if (instance == null) instance = this;
     
        ConveyorIn();

    }

    public void ConveyorIn(){
        giftAnimation[GameManager.instance.Index].transform.localScale = Vector3.one;
        giftAnimation[GameManager.instance.Index].clip = _in;
        giftAnimation[GameManager.instance.Index].Play();
    }

    public void ConveyorOut()
    {
        giftAnimation[GameManager.instance.Index].clip = _out;
        giftAnimation[GameManager.instance.Index].Play();
        GameManager.instance.Index++;

    }

}
