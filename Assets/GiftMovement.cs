using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMovement : MonoBehaviour {
  
    public void Init(){
        GiftSpawner.instance.ConveyorIn();
        Tap.instance.ZeroBox();
        BoxInSledge.instance.Add();
        SledgeUIHolder.instance.PutCounter();
    }
}
