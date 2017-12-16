using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    public Animation giftPanel;
    [SerializeField]
    private AnimationClip giftPanelIn;
    [SerializeField]
    private AnimationClip giftPanelOut;

    private void Awake()
    {
        if (instance == null) instance = this;

        giftPanelIn = giftPanel.GetClip("GiftSelectPanel");
        giftPanelOut = giftPanel.GetClip("GiftSelectPanelOut");
    }

    public void GiftPanelIn(){
        giftPanel.gameObject.SetActive(true);
        giftPanel.clip = giftPanelIn;
        giftPanel.Play();
    }

    public void GiftPanelOut(){
        giftPanel.clip = giftPanelOut;
        giftPanel.Play();
        GameManager.instance.isRunning = true;
    }
}
