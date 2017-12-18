using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckShopTemp : MonoBehaviour {

    private void OnEnable()
    {
        ShopManager.instance.CheckShopTemp(PrefManager.instance.GetShopTemp());
        ShopManager.instance.UpdateAllUI();
    }

}
