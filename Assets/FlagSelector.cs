using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagSelector : MonoBehaviour {
    private Image img;

    public Sprite[] flags;
    private void OnEnable()
    {
        var r = Random.Range(0, flags.Length);

        img.sprite = flags[r];
    }
}
