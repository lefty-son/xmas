using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    public static Fader instance;
    public AnimationCurve curve;
    private Image img;

    private void Awake()
    {
        if (instance == null) instance = this;
        img = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeOut());   
    }


    IEnumerator FadeOut(){
        var t = 1f;
        while ( t > 0 ){
            t -= Time.deltaTime;
            var a = curve.Evaluate(t);
            img.color = new Color(1f, 1f, 1f, a);
            yield return null;
        }
        gameObject.SetActive(false);
    }

}
