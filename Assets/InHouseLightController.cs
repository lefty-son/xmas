﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHouseLightController : MonoBehaviour {

    // 0 ~ 15

    private Light houseLight;

	// Use this for initialization
	void Awake() {
        houseLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Time.time);
        houseLight.intensity = (1 - (Mathf.PingPong(Time.time / GameManager.instance.secondsForHalf, 1))) * 15;
	}
}
