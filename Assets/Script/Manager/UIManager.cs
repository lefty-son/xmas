using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    public GameObject creditPanel;
    public GameObject tutorial;
    public GameObject hello, bye;

    public Animation dollarAnim;
    public Text dollarText;

    public Animation heartAnim;
    public Text heartText;

    public GameObject upgradePanel;

    public GameObject[] alerts;

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
        //Debug.Log("MAXED!");
        //maxStackAnim.Play();
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
        tutorial.SetActive(false);
        GiftManager.instance.CheckGiftTier();
        if(!upgradePanel.activeInHierarchy){
            // open
            Bye();
            AdsManager.instance.HideBanner();

        }
        else {

            // close
            if(PrefManager.instance.GetGiftTier() != 0){
                AdsManager.instance.ShowBanner();
            }
            Hello();
        }
        upgradePanel.SetActive(!upgradePanel.activeInHierarchy);
    }

    public void ShowRewardOccur(){
        if(PrefManager.instance.GetGiftTier() == 0){
            rewardOneBox.SetActive(true);
        }
        else {
            FeverSlider.instance.power = 0.125f;
            var r = Random.Range(0, 2);
            if (r == 0)
            {
                rewardOneBox.SetActive(true);
                //hello.SetActive(!hello.activeInHierarchy);
            }
            else
            {
                rewardMultipleBox.SetActive(true);
                //hello.SetActive(!hello.activeInHierarchy);
            }
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

    public void PlayAlert(){
        alerts[0].SetActive(true);
        alerts[1].SetActive(true);
    }

    public void StopAlert(){
        alerts[0].SetActive(false);
        alerts[1].SetActive(false);
    }
}
