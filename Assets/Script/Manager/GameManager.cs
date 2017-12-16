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
            if(stack >= maxStack){
                // Disable tap;
                Debug.Log("MAXED!");
                UIManager.instance.tap.interactable = false;
                UIManager.instance.MaxStacked();
            }
        }
    }

    public int maxStack;

    public bool isStart;
    public bool isRunning;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        maxStack = 5;
        Stack = 0;
        Index = 0;
        isStart = true;
        isRunning = true;
        secondsForHalf = 60f;
    }

    public void NextWave(){
        Index = 0;
        Tap.instance.NextWave();
        GiftSpawner.instance.NextWave();
    }

    public void ClearStack(){
        var income = Stack;
        Stack = 0;  
    }
}
