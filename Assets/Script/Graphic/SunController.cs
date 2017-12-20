using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour {

    public static SunController instance;

    public float daySpeed;
    private Light sunLight;

    private void Awake()
    {
        if (instance == null) instance = this;
        sunLight = GetComponent<Light>();

    }

    private void Start()
    {
        daySpeed = 3;
    }

    private void Update(){
        if(GameManager.instance.isStart){
            transform.eulerAngles += Vector3.up * Time.deltaTime * daySpeed;
        }
        sunLight.intensity =  1 -  Mathf.PingPong(Time.time / GameManager.instance.secondsForHalf, 1);
    }
}


