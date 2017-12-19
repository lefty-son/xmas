using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftManager : MonoBehaviour {

    public static GiftManager instance;

    public GameObject[] gifts, unlock, _name, price;
    public Image[] holder;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void OnEnable()
    {
        CheckGiftTier();
    }

    public void CheckGiftTier(){
        
        Debug.Log("CHECKING TIER ...");
        for (int i = 0; i <= PrefManager.instance.GetGiftTier() + 1; i++){
            gifts[i].SetActive(true);
        }

        holder[PrefManager.instance.GetGiftTier() + 1].color = Color.black;
        _name[PrefManager.instance.GetGiftTier() + 1].SetActive(false);
        price[PrefManager.instance.GetGiftTier() + 1].SetActive(true);
        unlock[PrefManager.instance.GetGiftTier() + 1].SetActive(true);
        
    }
}
