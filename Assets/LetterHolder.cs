using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterHolder : MonoBehaviour {

    public static int letterReward;

    public GameObject one, two;

    private void Start()
    {
        one.SetActive(false);
        two.SetActive(false);
        var t = GetComponent<Text>();
        if (PrefManager.instance.GetLanguage() == 1)
        {
            t.font = (Font)Resources.Load("Font/NanumBarunpenB");
        }
        else
        {
            t.font = (Font)Resources.Load("Font/libel-suit-rg");
        }

        t.text = Localizer.instance.GetLetter();
        if(letterReward == 2){
            two.SetActive(true);
        }
        else if(letterReward == 1){
            one.SetActive(true);
        }
    }
}
