using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSelector : MonoBehaviour {


    public Sprite[] boxes;
    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void OnEnable()
    {
        var r = Random.Range(0, boxes.Length);
        img.sprite = boxes[r];
    }
}
