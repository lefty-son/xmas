using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    public Animation dollarAnim;
    public Text dollarText;

    public Button tap, deliver;

    public Animation maxStackAnim;

    private void Awake()
    {
        if (instance == null) instance = this;
        tap.interactable = true;
        deliver.interactable = false;
    }

    public void EnableButtons()
    {
        tap.interactable = true;
        //deliver.interactable = true;
    }

    public void MaxStacked(){
        maxStackAnim.Play();
    }

    public void UpdateDollar(){
        dollarAnim.Play();
        UIPat.instance.PatIt();
        dollarText.text = PrefManager.instance.GetDolloar().ToString();
    }
}
