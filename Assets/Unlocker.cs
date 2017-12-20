using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour {

    public void Anim(){
        Debug.Log("Sibal");
        GiftManager.instance.OnUnlock();
    }
}
