using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var t = GetComponent<Text>();
        if (PrefManager.instance.GetLanguage() == 1)
        {
            t.font = (Font)Resources.Load("Font/NanumBarunpenB");
        }
        else
        {
            t.font = (Font)Resources.Load("Font/libel-suit-rg");
        }
	}
	
}
