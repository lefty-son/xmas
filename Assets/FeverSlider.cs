using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverSlider : MonoBehaviour {

    private Slider slider;
    public float speed, power;
    public static FeverSlider instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        slider = GetComponent<Slider>();
        slider.maxValue = 10f;
        slider.value = 0f;
        speed = 1f;
        power = 2.5f;
    }

    private void Update()
    {
        if(GameManager.instance.isRunning){
            slider.value -= Time.deltaTime * speed;
        }
        if(GameManager.instance.IsFever && slider.value == 0f){
            GameManager.instance.IsFever = false;
        }
    }

    public void SliderUp(){
        if(!GameManager.instance.IsFever){
            slider.value += power;
            CheckSlider();    
        }

    }

    private void CheckSlider(){
        if(slider.value >= slider.maxValue){
            GameManager.instance.IsFever = true;
        }
    }

}
