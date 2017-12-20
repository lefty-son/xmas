using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject inHouseHurray;

    [SerializeField]
    private bool isFever;
    public bool IsFever {
        get
        {
            return isFever;
        }
        set {
            isFever = value;
            if(isFever){
                secondsForHalf = 1f;
                inHouseHurray.gameObject.SetActive(true);
                SunController.instance.daySpeed = 30;

            }
            else {
                inHouseHurray.gameObject.SetActive(false);
                secondsForHalf = 60f;
                SunController.instance.daySpeed = 3;
            }
        }
    }

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
            if(stack >= PrefManager.instance.GetSledMaxCalc()){
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
            ShopManager.instance.UpdateAllUI();
        }
    }

    private int heart;
    public int Heart {
        get {
            return heart;
        }
        set {
            heart = value;
            PrefManager.instance.SetHeart(heart);
            UIManager.instance.UpdateHeart();
            ShopManager.instance.UpdateAllUI();
        }
    }


    public bool isStart;
    public bool isRunning;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        NowIncome = 0;
        Dollar = PrefManager.instance.GetDolloar();
        Heart = PrefManager.instance.GetHeart();
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

    public void EarnHeart(int _value){
        Debug.Log("ERAN HEART " + _value);
        Heart = Heart + _value;
    }

    public void SpendHeart(int _value){
        if(Heart >= _value){
            Heart = Heart - _value;
        }
        else {
            Debug.Log("NO HEART!");
            return;
        }
    }

    public int GetIndex(){
        var r = Random.Range(0, PrefManager.instance.GetGiftTier() + 1);
        return r;
    }
}
