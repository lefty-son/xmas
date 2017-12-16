﻿using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SledgeUIHolder : MonoBehaviour
{
    public static SledgeUIHolder instance;

    public GameObject panel;
    public GameObject dollar;
    public Animation counterAnim;
    public Text counterText;

    Vector3 uiPosition;

    private void Awake()
    {
        if (instance == null) instance = this;

    }
    private void Start()
    {
        uiPosition = Camera.main.WorldToScreenPoint(this.transform.position); 
    }

    public void HideAndInitCounter(){
        panel.SetActive(false);
        GameManager.instance.ClearStack();
        WhiteCounter();
    }

    public void PutCounter(){
        panel.SetActive(true);
        SledgeUIHolder.instance.UpdateCounterText();
        counterAnim.Play();
        panel.transform.position = uiPosition + new Vector3(75, 25, 0);
    }

    public void UpdateCounterText(){
        StringBuilder stb = new StringBuilder("X ");
        stb.Append(GameManager.instance.Stack);
        stb.Append(" / ");
        stb.Append(GameManager.instance.maxStack);
        counterText.text = stb.ToString();
    }

    public void Dollar(){
        dollar.SetActive(true);
        dollar.transform.position = uiPosition + new Vector3(75, 25, 0);
    }

    public void WhiteCounter(){
        counterText.color = Color.white;
    }

}