using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftManager : MonoBehaviour {

    public static GiftManager instance;

    public GameObject[] gifts, _name, price;
    public Button[] unlock;
    public Image[] holder;
    public Text[] priceText;
    public Text[] dollarPriceText;
    public GameObject shaker;
    public readonly int[] costInt= { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 } ;

    public readonly int[] giftCosts = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14};

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
            unlock[i].onClick.AddListener(AnimUnlock);
            unlock[i].gameObject.SetActive(false);
            holder[i].color = Color.white;
            _name[i].gameObject.SetActive(true);
            //price[i].gameObject.SetActive(false);
            priceText[i].text = "";
            //Debug.Log(costInt[i]);
            StringBuilder stb = new StringBuilder(costInt[i].ToString());
            stb.Append("$");
            dollarPriceText[i].text = stb.ToString();
        }
        

        for (int i = 0; i <= PrefManager.instance.GetGiftTier() + 1; i++){
            gifts[i].SetActive(true);
            price[i].SetActive(false);
            priceText[i].text = "";
        }

        var cost = giftCosts[PrefManager.instance.GetGiftTier()];

        priceText[PrefManager.instance.GetGiftTier() + 1].text = cost.ToString();
        holder[PrefManager.instance.GetGiftTier() + 1].color = Color.black;
        _name[PrefManager.instance.GetGiftTier() + 1].SetActive(false);
        price[PrefManager.instance.GetGiftTier() + 1].SetActive(true);
        unlock[PrefManager.instance.GetGiftTier() + 1].gameObject.SetActive(true);






        if (PrefManager.instance.GetHeart() >= cost)
        {
            // Enable unlock;
            unlock[PrefManager.instance.GetGiftTier() + 1].interactable = true;
            UIManager.instance.PlayAlert();
            if(PlayerPrefs.GetInt("TUTORIAL") == 0){
                UIManager.instance.tutorial.SetActive(true);
                PlayerPrefs.SetInt("TUTORIAL", 1);
            }
        }
        else {
            unlock[PrefManager.instance.GetGiftTier() + 1].interactable = false;
            UIManager.instance.StopAlert();
        }

    }

    public void AnimUnlock(){
        unlock[PrefManager.instance.GetGiftTier() + 1].GetComponent<Animation>().Play();
    }

    public void OnUnlock(){
        shaker.SetActive(true);
        Shaker.instance.realImage = holder[PrefManager.instance.GetGiftTier() + 1].sprite;
        Shaker.instance.nameHolder.text = Localizer.instance.GetTextFromLocal(_name[PrefManager.instance.GetGiftTier() + 1].name);
    }
}
