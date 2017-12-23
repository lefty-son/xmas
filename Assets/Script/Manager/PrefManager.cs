﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefManager : MonoBehaviour
{

    public static PrefManager instance;

    public GameObject welcome;

    private readonly string DOLLAR = "DOLLAR";
    private readonly string HEART = "HEART";
    private readonly string FIRST_VISIT = "FIRST_VISIT";
    private readonly string SHOP_TEMP = "SHOP_TEMP";
    private readonly string LANGUA = "LANGUA";

    private readonly string TUTORIAL = "TUTORIAL";

    private readonly string SLED_MAX_LEVEL = "SLED_MAX_LEVEL";
    private readonly string SLED_SPEED_LEVEL = "SLED_SPEED_LEVEL";
    private readonly string SANTA_LEVEL = "SANTA_LEVEL";
    private readonly string CONVEY_LEVEL = "CONVEY_LEVEL";

    private readonly string GIFT_TIER = "GIFT_TIER";

    private void Awake()
    {
        if (instance == null) instance = this;
        Init();
    }

    private void Init()
    {
        if (PlayerPrefs.HasKey(FIRST_VISIT))
        {
            // Continue
            welcome.SetActive(false);
            UIManager.instance.StartLetter();
        }
        else
        {
            welcome.SetActive(true);
            // A new user
            PlayerPrefs.SetInt(FIRST_VISIT, 1);
            PlayerPrefs.SetInt(DOLLAR, 0);
            PlayerPrefs.SetInt(SHOP_TEMP, 2);
            PlayerPrefs.SetInt(HEART, 0);

            PlayerPrefs.SetInt(SANTA_LEVEL, 0);
            PlayerPrefs.SetInt(CONVEY_LEVEL, 0);
            PlayerPrefs.SetInt(SLED_MAX_LEVEL, 0);
            PlayerPrefs.SetInt(SLED_SPEED_LEVEL, 0);
            PlayerPrefs.SetInt(GIFT_TIER, 0);

            PlayerPrefs.SetInt(TUTORIAL, 0);

            if (Application.systemLanguage == SystemLanguage.English)
            {
                PlayerPrefs.SetInt(LANGUA, 0);
            }
            else if (Application.systemLanguage == SystemLanguage.Korean)
            {
                PlayerPrefs.SetInt(LANGUA, 1);
            }
            else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
            {
                PlayerPrefs.SetInt(LANGUA, 2);
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                PlayerPrefs.SetInt(LANGUA, 3);
            }
            else if(Application.systemLanguage == SystemLanguage.Finnish){
                PlayerPrefs.SetInt(LANGUA, 4);
            }

            UIManager.instance.NewbieLetter();
        }
    }

    #region INFO

    public int GetHeart(){
        return PlayerPrefs.GetInt(HEART);
    }

    public void SetHeart(int _value){
        PlayerPrefs.SetInt(HEART, _value);
    }

    public int GetLanguage()
    {
        return PlayerPrefs.GetInt(LANGUA);
    }

    public void SetLanguage(int _value)
    {
        PlayerPrefs.SetInt(LANGUA, _value);
    }

    public int GetShopTemp()
    {
        return PlayerPrefs.GetInt(SHOP_TEMP);
    }

    public void SetShopTemp(int _value)
    {
        PlayerPrefs.SetInt(SHOP_TEMP, _value);
    }

    public int GetDolloar()
    {
        return PlayerPrefs.GetInt(DOLLAR);
    }

    public void SetDollar(int _value)
    {
        PlayerPrefs.SetInt(DOLLAR, _value);
    }

    #endregion

    #region UPGRADE

    public int GetSantaLevel()
    {
        return PlayerPrefs.GetInt(SANTA_LEVEL);
    }

    public void SetSantaLevel()
    {
        PlayerPrefs.SetInt(SANTA_LEVEL, GetSantaLevel() + 1);
    }

    public float GetSantaCalc()
    {
        return 1f + (GetSantaLevel() * 0.1f);
    }

    public int GetConveyLevel()
    {
        return PlayerPrefs.GetInt(CONVEY_LEVEL);
    }

    public void SetConveySpeed()
    {
        PlayerPrefs.SetInt(CONVEY_LEVEL, GetConveyLevel() + 1);
    }

    public float GetConveyCalc()
    {
        return 1f + (GetConveyLevel() * 0.1f);
    }

    public int GetSledMaxLevel()
    {
        return PlayerPrefs.GetInt(SLED_MAX_LEVEL);
    }

    public void SetSledMaxLevel()
    {
        PlayerPrefs.SetInt(SLED_MAX_LEVEL, GetSledMaxLevel() + 1);
    }

    public int GetSledMaxCalc()
    {
        return 5 + GetSledMaxLevel();
    }

    public int GetSledSpeedLevel()
    {
        return PlayerPrefs.GetInt(SLED_SPEED_LEVEL);
    }

    public void SetSledSpeedLevel()
    {
        PlayerPrefs.SetInt(SLED_SPEED_LEVEL, GetSledSpeedLevel() + 1);
    }

    public float GetSledSpeedCalc()
    {
        return 1f + (GetSledSpeedLevel() * 0.1f);
    }

    public int GetGiftTier(){
        return PlayerPrefs.GetInt(GIFT_TIER);
    }

    public void SetGiftTier(){
        PlayerPrefs.SetInt(GIFT_TIER, GetGiftTier() + 1);
    }

    #endregion


    #region DEBUG

    public void Cheat()
    {
        GameManager.instance.Dollar = 10000;
        GameManager.instance.Heart = 500;
        PlayerPrefs.SetInt(GIFT_TIER, 0);
        AdsManager.instance.ShowBanner();
    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        AdsManager.instance.HideBanner();
    }

    #endregion
}
