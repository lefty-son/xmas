using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SledgeUIHolder : MonoBehaviour
{
    public static SledgeUIHolder instance;

    public GameObject panel;
    public Animation counterAnim;

    Vector3 uiPosition;

    private void Awake()
    {
        if (instance == null) instance = this;

    }
    private void Start()
    {
        uiPosition = Camera.main.WorldToScreenPoint(this.transform.position); 
    }

    public void PutCounter(){
        panel.SetActive(true);
        counterAnim.Play();
        panel.transform.position = uiPosition + new Vector3(75, 25, 0);
    }
}