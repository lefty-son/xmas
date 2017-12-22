using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    private void OnEnable()
    {
        SoundManager.instance.Alert();
    }
}
