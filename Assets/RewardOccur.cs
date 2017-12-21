using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardOccur : MonoBehaviour {
    public static RewardOccur instance;
    private Animation anim;
    private Button btn;

    private void Awake()
    {
        if (instance == null) instance = this;
        anim = GetComponent<Animation>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Show);

    }

    public void Occurs(){
        anim.Play();
        transform.localScale = Vector3.one;
    }

    public void Show(){
        transform.localScale = Vector3.zero;    
        FeverSlider.instance.isShown = false;
        UIManager.instance.ShowRewardOccur();
    }


}
