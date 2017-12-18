using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefManager : MonoBehaviour {

    public static PrefManager instance;

    private readonly string DOLLAR = "DOLLAR";
    private readonly string FIRST_VISIT = "FIRST_VISIT";
    private readonly string MAX_STACK = "MAX_STACK";
    private readonly string LEVEL = "LEVEL";
    private readonly string POWER = "POWER";
    private readonly string SLEDGE_SPEED = "SLEDGE_SPEED";

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
            PlayerPrefs.SetInt(LEVEL, 1);
            PlayerPrefs.SetFloat(POWER, 1f);
            PlayerPrefs.SetFloat(SLEDGE_SPEED, 1f);
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

    public int GetLevel(){
        return PlayerPrefs.GetInt(LEVEL);
    }

    public void SetLevel(){
        PlayerPrefs.SetInt(LEVEL, GetLevel() + 1);
    }

    public float GetPower(){
        return PlayerPrefs.GetFloat(POWER);
    }

    public void SetPower(float _value){
        PlayerPrefs.SetFloat(POWER, _value);
    }

    public float GetSledgeSpeed()
    {
        return PlayerPrefs.GetFloat(SLEDGE_SPEED);
    }

    public void SetSledgeSpeed(float _value)
    {
        PlayerPrefs.SetFloat(SLEDGE_SPEED, _value);
    }

    public void ResetAll(){
        PlayerPrefs.DeleteAll();
    }

}
