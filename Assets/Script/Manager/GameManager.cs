using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public float secondsForHalf;

    private int index;
    public int Index {
        get {
            return index;
        }
        set {
            index = value;
            if (index >= 2) index = 0;
        }
    }

    private int stack;
    public int Stack {
        get {
            return stack;
        }
        set {
            stack = value;
        }
    }

    public bool isStart;
    public bool isRunning;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        index = 0;
        isStart = true;
        isRunning = true;
        secondsForHalf = 60f;
    }

    public void NextWave(){
        Index = 0;
        Tap.instance.NextWave();
        GiftSpawner.instance.NextWave();
    }
}
