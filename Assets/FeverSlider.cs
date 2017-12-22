using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverSlider : MonoBehaviour {

    private Slider slider;
    public bool isShown;
    public float speed, power;
    public static FeverSlider instance;
    public bool tappable;

    private void Awake()
    {
        if (instance == null) instance = this;

        tappable = true;
        isShown = false;
        slider = GetComponent<Slider>();
        slider.maxValue = 10f;
        slider.value = 0f;
        speed = 0;
        if(PrefManager.instance.GetGiftTier() == 0){
            power = 0.275f;
        }
        else {
            power = 0.125f;
        }

    }

    public void Init(){
        slider.value = 0;
    }

    private void Update()
    {
        if(GameManager.instance.isRunning && !isShown){
            slider.value -= Time.deltaTime * speed;
        }
    }

    public void SliderUp(){
        if(!GameManager.instance.IsFever && !isShown){
            slider.value += power;
            CheckSlider();   
        }

    }

    private void CheckSlider(){
        if(slider.value >= slider.maxValue && !isShown){
            RewardOccur.instance.Occurs();
            slider.value = 0;
            isShown = true;
        }
    }

}
