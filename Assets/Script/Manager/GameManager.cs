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
            if (index >= 4) index = 0;
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

    private int nowIncome;
    public int NowIncome {
        get {
            return nowIncome;
        }
        set {
            nowIncome = value;
        }
    }

    private int dollar;
    public int Dollar{
        get{ 
            return dollar;
        }
        set {
            dollar = value;
            PrefManager.instance.SetDollar(dollar);
            UIManager.instance.UpdateDollar();
        }
    }

    public int maxStack;

    public bool isStart;
    public bool isRunning;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        NowIncome = 0;
        maxStack = PrefManager.instance.GetMaxStack();
        Dollar = PrefManager.instance.GetDolloar();
        Stack = 0;
        Index = 0;
        isStart = false;
        isRunning = true;
        secondsForHalf = 60f;
    }

    public void NextWave(){
        Index = 0;
        Tap.instance.NextWave();
        GiftSpawner.instance.NextWave();
    }

    public void ClearStack(){
        var income = NowIncome;
        EarnDolloar(income);
        Stack = 0;
        NowIncome = 0;
    }

    public void EarnDolloar(int _value){
        // Plus dollar
        Dollar = Dollar + _value;
    }

    public void SpendDollar(int _value){
        if(Dollar >= _value){
            Dollar = Dollar - _value;
        }
        else {
            Debug.Log("NO MONEY!");
            return;
        }

    }

    public int GetIndex(){
        var r = Random.Range(0, 2);
        return r;
    }
}
