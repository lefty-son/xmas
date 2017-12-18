using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInSledge : MonoBehaviour {

    public static BoxInSledge instance;

    private int index;

    public GameObject[] boxes;

    private void Awake()
    {
        if (instance == null) instance = this;
        Init();
    }

    public void Init(){
        foreach(GameObject go in boxes){
            go.SetActive(false);
        }
        index = 0;
    }

    public void Add(){
        if (index >= 7) return;
        boxes[index++].SetActive(true);
    }



}
