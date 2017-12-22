using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour {

    public void Anim(){
        GiftManager.instance.OnUnlock();
    }
}
