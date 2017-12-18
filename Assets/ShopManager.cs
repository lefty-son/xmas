using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public static ShopManager instance;

    private readonly int INIT_UPGRADE_SANTA = 10;
    private readonly int INIT_UPGRADE_CONVEY = 10;
    private readonly int INIT_SLED_MAX = 10;
    private readonly int INIT_SLED_SPEED = 10;

    public Text santaCost, conveyCost, sledMaxCost, sledSpeedCost;
    public Button santaButton, conveyButton, sledMaxButton, sledSpeedButton;

    public GameObject upgrade, sledge, gift;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

#region PANEL

    public void OnUpgrade(){
        sledge.SetActive(false);
        gift.SetActive(false);
        upgrade.SetActive(true);
        PrefManager.instance.SetShopTemp(0);
    }

    public void OnSledge()
    {
        upgrade.SetActive(false);
        gift.SetActive(false);
        sledge.SetActive(true);
        PrefManager.instance.SetShopTemp(1);
    }

    public void OnGift()
    {
        upgrade.SetActive(false);
        sledge.SetActive(false);
        gift.SetActive(true);
        PrefManager.instance.SetShopTemp(2);
    }

    public void CheckShopTemp(int _value){
        if(_value == 0){
            OnUpgrade();
        }
        else if(_value == 1){
            OnSledge();
        }
        else if (_value == 2)
        {
            OnGift();
        }
        
    }

#endregion

    public void UpgradeSanta(){
        PrefManager.instance.SetSantaLevel();
        UpdateSanta();
    }

    public void UpgradeConvey()
    {
        PrefManager.instance.SetConveySpeed();
        UpdateConvey();
    }

    public void UpgradeSledMax()
    {
        PrefManager.instance.SetSledMaxLevel();
        UpdateSledMax();
    }

    public void UpgradeSledSpeed()
    {
        PrefManager.instance.SetSledSpeedLevel();
        UpdateSledSpeed();
    }

    public void UpdateAllUI(){
        UpdateSanta();
        UpdateConvey();
        UpdateSledMax();
        UpdateSledSpeed();
    }

    private void UpdateSanta(){
        var cost = INIT_UPGRADE_SANTA * (PrefManager.instance.GetSantaLevel() + 1);
        if(GameManager.instance.Dollar >= cost){
            santaButton.interactable = true;
        }
        else{
            santaButton.interactable = false;
        }
        // TODO: Increase Level Handling
        santaCost.text = cost.ToString();
    }
    private void UpdateConvey()
    {
        var cost = INIT_UPGRADE_CONVEY * (PrefManager.instance.GetConveyLevel() + 1);
        if (GameManager.instance.Dollar >= cost)
        {
            conveyButton.interactable = true;
        }
        else
        {
            conveyButton.interactable = false;
        }
        // TODO: Increase Level Handling
        conveyCost.text = cost.ToString();
    }
    private void UpdateSledMax()
    {
        var cost = INIT_SLED_MAX * (PrefManager.instance.GetSledMaxLevel() + 1);
        if (GameManager.instance.Dollar >= cost)
        {
            sledMaxButton.interactable = true;
        }
        else
        {
            sledMaxButton.interactable = false;
        }
        // TODO: Increase Level Handling
        sledMaxCost.text = cost.ToString();
    }
    private void UpdateSledSpeed()
    {
        var cost = INIT_SLED_SPEED * (PrefManager.instance.GetSledSpeedLevel() + 1);
        if (GameManager.instance.Dollar >= cost)
        {
            sledSpeedButton.interactable = true;
        }
        else
        {
            sledSpeedButton.interactable = false;
        }
        // TODO: Increase Level Handling
        sledSpeedCost.text = cost.ToString();
    }
}
