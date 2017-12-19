using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftManager : MonoBehaviour {

    public static GiftManager instance;

    public GameObject[] gifts, unlock, _name, price;
    public Image[] holder;
    public Text[] priceText;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void OnEnable()
    {
        CheckGiftTier();
    }

    public void CheckGiftTier(){

        for (int i = 0; i < gifts.Length; i++){
            gifts[i].SetActive(false);
        }
        
        Debug.Log("CHECKING TIER ...");
        for (int i = 0; i <= PrefManager.instance.GetGiftTier() + 1; i++){
            gifts[i].SetActive(true);
            price[i].SetActive(false);
            priceText[i].text = "";
        }

        priceText[PrefManager.instance.GetGiftTier() + 1].text = "12";
        holder[PrefManager.instance.GetGiftTier() + 1].color = Color.black;
        _name[PrefManager.instance.GetGiftTier() + 1].SetActive(false);
        price[PrefManager.instance.GetGiftTier() + 1].SetActive(true);
        unlock[PrefManager.instance.GetGiftTier() + 1].SetActive(true);

    }

    public void OnUnlock(){
        
    }
}
