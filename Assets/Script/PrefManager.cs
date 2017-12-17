using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefManager : MonoBehaviour {

    public static PrefManager instance;

    private readonly string DOLLAR = "DOLLAR";
    private readonly string FIRST_VISIT = "FIRST_VISIT";
    private readonly string MAX_STACK = "MAX_STACK";

    private void Awake()
    {
        if (instance == null) instance = this;
        Init();
    }

    private void Init(){
        if(PlayerPrefs.HasKey(FIRST_VISIT)){
            // Continue
        }
        else {
            // A new user
            PlayerPrefs.SetInt(FIRST_VISIT, 1);
            PlayerPrefs.SetInt(DOLLAR, 0);
            PlayerPrefs.SetInt(MAX_STACK, 5);
        }
    }



    public int GetDolloar(){
        return PlayerPrefs.GetInt(DOLLAR);
    }

    public void SetDollar(int _value)
    {
        PlayerPrefs.SetInt(DOLLAR, _value);
    }

    public int GetMaxStack(){
        return PlayerPrefs.GetInt(MAX_STACK);
    }

    public void SetMaxStack(int _value){
        PlayerPrefs.SetInt(MAX_STACK, _value);
    }

    public void ResetAll(){
        PlayerPrefs.DeleteAll();
    }

}
