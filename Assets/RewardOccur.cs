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
    }

    public void Show(){
        UIManager.instance.ShowRewardOccur();
    }


}
