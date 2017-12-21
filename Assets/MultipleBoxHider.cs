﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleBoxHider : MonoBehaviour {

    public GameObject[] boxes;
    public Text goldText;
    public GameObject[] rewards;
    public static MultipleBoxHider instance;
    public void Init(){
        goldText.text = "";
        foreach(GameObject go in rewards){
            go.SetActive(false);
        }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void OnEnable()
    {
        foreach(GameObject go in boxes){
            go.transform.localScale = Vector3.one;
        }
    }

    public void AnimateHide(){
        foreach (GameObject go in boxes)
        {
            if(!go.GetComponent<MultipleBoxShaker>().chosen){
                go.GetComponent<Animation>().Play();
            }
        }
    }

    private void OnDisable()
    {
        Init();
    }

    public void ShowRandomReward(){
        var r = Random.Range(0, 5); // 0 1 2 3 4
        if(r < 3){
            // gold
            var gold = (PrefManager.instance.GetGiftTier() + 1) * (r + 1) * (PrefManager.instance.GetSledMaxLevel() + 1) * 10;
            goldText.text = gold.ToString();
            rewards[0].SetActive(true);
            GameManager.instance.EarnDolloar(gold);
        }
        else {
            // fever
            rewards[1].SetActive(true);
        }

    }
}
