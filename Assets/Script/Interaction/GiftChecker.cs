using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftChecker : MonoBehaviour {

    public Button btn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Gift")){
            GameManager.instance.isRunning = false;
            btn.interactable = true;    
        }
    }
}
