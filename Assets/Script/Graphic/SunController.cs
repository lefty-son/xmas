using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour {
    public float daySpeed;

    private void Update(){
        if(GameManager.instance.isStart){
            transform.eulerAngles += Vector3.up * Time.deltaTime * daySpeed;
        }

    }
}
