﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    public GameObject creditPanel;

    public GameObject hello, bye;

    public Animation dollarAnim;
    public Text dollarText;

    public Animation heartAnim;
    public Text heartText;

    public GameObject upgradePanel;

    public Button tap;

    public Animation maxStackAnim;

    public GameObject rewardOneBox, rewardMultipleBox;

    private void Awake()
    {
        if (instance == null) instance = this;
        tap.interactable = true;
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void OnCredit(){
        creditPanel.SetActive(true);
    }

    public void EnableButtons()
    {
        tap.interactable = true;
    }

    public void MaxStacked(){
        maxStackAnim.Play();
    }

    public void UpdateDollar(){
        dollarAnim.Play();
        dollarText.text = PrefManager.instance.GetDolloar().ToString();
    }

    public void UpdateHeart(){
        heartAnim.Play();
        heartText.text = PrefManager.instance.GetHeart().ToString();
    }

    public void ToggleUpgradePanel(){

        if(!upgradePanel.activeInHierarchy){
            Bye();
        }
        else {
            Hello();
        }
        upgradePanel.SetActive(!upgradePanel.activeInHierarchy);
    }

    public void ShowRewardOccur(){
        var r = Random.Range(0, 2);
        if(r == 0){
            rewardOneBox.SetActive(true);
            //hello.SetActive(!hello.activeInHierarchy);
        }
        else {
            rewardMultipleBox.SetActive(true);
            //hello.SetActive(!hello.activeInHierarchy);
        }
        Bye();
    }

    public void Hello(){
        hello.transform.localScale = Vector3.one;
        bye.transform.localScale = Vector3.one;
    }

    public void Bye(){
        hello.transform.localScale = Vector3.zero;
        bye.transform.localScale = Vector3.zero;   
    }
}
