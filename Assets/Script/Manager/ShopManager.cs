using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public static ShopManager instance;

    // Modiy here to adjust upgrade cost
    private readonly int INIT_UPGRADE_SANTA = 10;
    private readonly int INIT_UPGRADE_CONVEY = 10;
    private readonly int INIT_SLED_MAX = 10;
    private readonly int INIT_SLED_SPEED = 10;

    // Modify here to adjust max level
    private readonly int MAXLVL_UPGRADE_SANTA = 14;
    private readonly int MAXLVL_UPGRADE_CONVEY = 14;
    private readonly int MAXLVL_SLED_MAX = 14;
    private readonly int MAXLVL_SLED_SPEED = 14;

    public Text santaCost, conveyCost, sledMaxCost, sledSpeedCost;
    public Button santaButton, conveyButton, sledMaxButton, sledSpeedButton;
    public Image upgradeNavi, sledNavi, giftNavi, currencyNavi;
    public Slider santaSlider, conveySlider, sledMaxSlider, sledSpeedSlider;

    public GameObject upgrade, sledge, gift, currency;



    private void Awake()
    {
        if (instance == null) instance = this;
    }

    #region PANEL

    public void OnUpgrade(){
        sledge.SetActive(false);
        gift.SetActive(false);
        currency.SetActive(false);
        upgrade.SetActive(true);
        sledNavi.color = Color.white;
        giftNavi.color = Color.white;
        currencyNavi.color = Color.white;
        upgradeNavi.color = Color.gray;
        PrefManager.instance.SetShopTemp(0);
    }

    public void OnSledge()
    {
        upgrade.SetActive(false);
        gift.SetActive(false);
        currency.SetActive(false);
        sledge.SetActive(true);
        upgradeNavi.color = Color.white;
        giftNavi.color = Color.white;
        currencyNavi.color = Color.white;
        sledNavi.color = Color.gray;
        PrefManager.instance.SetShopTemp(1);
    }

    public void OnGift()
    {
        upgrade.SetActive(false);
        sledge.SetActive(false);
        currency.SetActive(false);
        gift.SetActive(true);
        upgradeNavi.color = Color.white;
        sledNavi.color = Color.white;
        currencyNavi.color = Color.white;
        giftNavi.color = Color.gray;
        PrefManager.instance.SetShopTemp(2);
    }

    public void OnCurrency(){
        upgrade.SetActive(false);
        sledge.SetActive(false);
        gift.SetActive(false);
        currency.SetActive(true);   
        upgradeNavi.color = Color.white;
        sledNavi.color = Color.white;
		giftNavi.color = Color.white;
        currencyNavi.color = Color.gray;
        PrefManager.instance.SetShopTemp(3);
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
        else if(_value == 3){
            OnCurrency();
        }
        
    }

    #endregion

    #region Upgrades

    public void UpgradeSanta(){
        GameManager.instance.SpendDollar(INIT_UPGRADE_SANTA * (PrefManager.instance.GetSantaLevel() + 1) * (PrefManager.instance.GetSantaLevel() + 1));
        PrefManager.instance.SetSantaLevel();
        UpdateAllUI();
    }

    public void UpgradeConvey()
    {
        GameManager.instance.SpendDollar(INIT_UPGRADE_CONVEY * (PrefManager.instance.GetConveyLevel() + 1) * (PrefManager.instance.GetConveyLevel() + 1));
        PrefManager.instance.SetConveySpeed();
        UpdateAllUI();
    }

    public void UpgradeSledMax()
    {
        GameManager.instance.SpendDollar(INIT_SLED_MAX * (PrefManager.instance.GetSledMaxLevel() + 1) * (PrefManager.instance.GetSledMaxLevel() + 1));
        PrefManager.instance.SetSledMaxLevel();
        UpdateAllUI();
    }

    public void UpgradeSledSpeed()
    {
        GameManager.instance.SpendDollar(INIT_SLED_SPEED * (PrefManager.instance.GetSledSpeedLevel() + 1) * (PrefManager.instance.GetSledSpeedLevel() + 1));
        PrefManager.instance.SetSledSpeedLevel();
        UpdateAllUI();
    }

#endregion

    public void UpdateAllUI(){
        UpdateSanta();
        UpdateConvey();
        UpdateSledMax();
        UpdateSledSpeed();

        // TODO: heart ui
    }

    private void UpdateSanta(){
        var cost = INIT_UPGRADE_SANTA * (PrefManager.instance.GetSantaLevel() + 1) * (PrefManager.instance.GetSantaLevel() + 1) ;
        santaSlider.value = PrefManager.instance.GetSantaLevel();
        santaSlider.maxValue = MAXLVL_UPGRADE_SANTA;
        if(GameManager.instance.Dollar >= cost && PrefManager.instance.GetSantaLevel() < MAXLVL_UPGRADE_SANTA){
            santaButton.interactable = true;
        }
        else{
            santaButton.interactable = false;
        }
        santaCost.text = cost.ToString();
    }

    private void UpdateConvey()
    {
        var cost = INIT_UPGRADE_CONVEY * (PrefManager.instance.GetConveyLevel() + 1) * (PrefManager.instance.GetConveyLevel() + 1);
        conveySlider.value = PrefManager.instance.GetConveyLevel();
        conveySlider.maxValue = MAXLVL_UPGRADE_CONVEY;
        if (GameManager.instance.Dollar >= cost && PrefManager.instance.GetConveyLevel() < MAXLVL_UPGRADE_CONVEY)
        {
            conveyButton.interactable = true;
        }
        else
        {
            conveyButton.interactable = false;
        }
        conveyCost.text = cost.ToString();
    }

    private void UpdateSledMax()
    {
        var cost = INIT_SLED_MAX * (PrefManager.instance.GetSledMaxLevel() + 1) * (PrefManager.instance.GetSledMaxLevel() + 1);
        sledMaxSlider.value = PrefManager.instance.GetSledMaxLevel();
        sledMaxSlider.maxValue = MAXLVL_SLED_MAX;
            if (GameManager.instance.Dollar >= cost && PrefManager.instance.GetSledMaxLevel() < MAXLVL_SLED_MAX)
        {
            sledMaxButton.interactable = true;
        }
        else
        {
            sledMaxButton.interactable = false;
        }
        sledMaxCost.text = cost.ToString();
    }

    private void UpdateSledSpeed()
    {
        var cost = INIT_SLED_SPEED * (PrefManager.instance.GetSledSpeedLevel() + 1) * (PrefManager.instance.GetSledSpeedLevel() + 1);
        sledSpeedSlider.value = PrefManager.instance.GetSledSpeedLevel();
        sledSpeedSlider.maxValue = MAXLVL_SLED_SPEED;
        if (GameManager.instance.Dollar >= cost && PrefManager.instance.GetSledSpeedLevel() < MAXLVL_SLED_SPEED)
        {
            sledSpeedButton.interactable = true;
        }
        else
        {
            sledSpeedButton.interactable = false;
        }
        sledSpeedCost.text = cost.ToString();
    }
}
