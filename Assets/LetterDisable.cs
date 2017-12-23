using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisable : MonoBehaviour {

    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Off);
    }

    public void Off(){
        if(LetterHolder.letterReward == 0){
            
        }
        else {
            GameManager.instance.EarnHeart(LetterHolder.letterReward);
        }
        UIManager.instance.StartLetter();
        transform.parent.gameObject.SetActive(false);
    }

}
