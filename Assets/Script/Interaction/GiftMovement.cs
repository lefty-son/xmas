using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GiftMovement : MonoBehaviour {

    public Button btn;

    public void DisableDeliverFor_a_Moment(){
        btn.interactable = false;
    }
  
    public void Init(){
        btn.interactable = true;
        GiftSpawner.instance.ConveyorIn();
        Tap.instance.ZeroBox();
        BoxInSledge.instance.Add();
        SledgeUIHolder.instance.PutCounter();
    }

    public void ShowInfo(){
        GiftInfoHolder.instance.ShowInfo();
    }
}
