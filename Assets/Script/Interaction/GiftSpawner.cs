using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour {
    public static GiftSpawner instance;

    public Animation[] giftAnimation;

    public int uniqIndex;

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

    public void ConveyorIn()
    {
        Debug.Log("CONV IN");
        uniqIndex = GameManager.instance.GetIndex();
        giftAnimation[uniqIndex].transform.localScale = Vector3.one;
        giftAnimation[uniqIndex].clip = _in;
        giftAnimation[uniqIndex][_in.name].speed = PrefManager.instance.GetSledSpeedCalc();
        giftAnimation[uniqIndex].Play();
        Debug.Log("CONV DONE");
    }

    public void ConveyorOut()
    {
        GiftInfoHolder.instance.HideInfo();
        giftAnimation[uniqIndex].clip = _out;
        giftAnimation[uniqIndex][_out.name].speed = PrefManager.instance.GetSledSpeedCalc();
        giftAnimation[uniqIndex].Play();
        var getDollar = Tap.instance.reward[uniqIndex].dollar;
        GameManager.instance.NowIncome += getDollar;
        //GameManager.instance.GetIndex()++;
    }

}
