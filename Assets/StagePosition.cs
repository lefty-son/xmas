using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePosition : MonoBehaviour {
    public GameObject starting;
    public GameObject[] stages;

    public static StagePosition instance;

    private int currentIndex;
    public int CurrentIndex{
        get{
            return currentIndex;
        }
        set {
            currentIndex = value;
            MovePosition(currentIndex);
        }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void MovePosition(int _index){
        stages[_index % 4].transform.localPosition = new Vector3(0f, 0f, 200 * (_index + 4));
    }


}
