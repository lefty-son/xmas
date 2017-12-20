using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHolder : MonoBehaviour {

    private void Start()
    {
        var t = GetComponent<Text>();
        if(PrefManager.instance.GetLanguage() == 1){
            t.font = (Font)Resources.Load("Font/NanumBarunpenB");
        }
        else {
            t.font = (Font)Resources.Load("Font/libel-suit-rg");
        }

        t.text = Localizer.instance.GetTextFromLocal(gameObject.name);
    }
}
