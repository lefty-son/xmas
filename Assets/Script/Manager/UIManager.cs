using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    public GameObject hello;

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
        hello.SetActive(!hello.activeInHierarchy);
        upgradePanel.SetActive(!upgradePanel.activeInHierarchy);
    }

    public void ShowRewardOccur(){
        var r = Random.Range(0, 2);
        if(r == 0){
            rewardOneBox.SetActive(true);
        }
        else if(r == 1){
            rewardMultipleBox.SetActive(true);
        }

    }
}
