using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour {
    public static GiftSpawner instance;

    public Animation[] giftAnimation;
    public int uniqIndex;
    public AnimationClip _in, _out;

    private void Start()
    {
        if (instance == null) instance = this;
        ConveyorIn();
    }

    public void NextWave()
    {
        foreach (Animation anim in giftAnimation)
        {
            anim.transform.localPosition = Vector3.zero;
        }
        ConveyorIn();
    }

    public void ConveyorIn()
    {
        uniqIndex = GameManager.instance.GetIndex();
        giftAnimation[uniqIndex].transform.localScale = Vector3.one;
        giftAnimation[uniqIndex].clip = _in;
        if(GameManager.instance.IsRewardFever){
            giftAnimation[uniqIndex][_in.name].speed = PrefManager.instance.GetConveyCalc() * 2;
        }
        else {
            giftAnimation[uniqIndex][_in.name].speed = PrefManager.instance.GetConveyCalc();

        }
        giftAnimation[uniqIndex].Play();
    }

    public void ConveyorOut()
    {
        GiftInfoHolder.instance.HideInfo();
        giftAnimation[uniqIndex].clip = _out;
        if (GameManager.instance.IsRewardFever)
        {
            giftAnimation[uniqIndex][_out.name].speed = PrefManager.instance.GetConveyCalc() * 2;
        }
        else
        {
            giftAnimation[uniqIndex][_out.name].speed = PrefManager.instance.GetConveyCalc();

        }
        giftAnimation[uniqIndex].Play();
        var getDollar = Tap.instance.reward[uniqIndex].dollar;
        GameManager.instance.NowIncome += getDollar;
        //GameManager.instance.GetIndex()++;
    }

   
}
