using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour {
    [SerializeField]
    private float daySpeed;
    private Light sunLight;

    private void Awake()
    {
        sunLight = GetComponent<Light>();

    }

    private void Start()
    {
        daySpeed = GameManager.instance.secondsForHalf / 20;
    }

    private void Update(){
        if(GameManager.instance.isStart){
            transform.eulerAngles += Vector3.up * Time.deltaTime * daySpeed;
        }
        sunLight.intensity =  1 -  Mathf.PingPong(Time.time / GameManager.instance.secondsForHalf, 1);
    }
}
