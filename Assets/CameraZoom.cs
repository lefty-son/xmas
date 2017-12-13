using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    public AnimationCurve curve;

	// Use this for initialization
	void Start () {
        StartCoroutine(ZoomInOnStart());
	}

    private IEnumerator ZoomInOnStart(){
        var t = 0f;
        while(t < 2f){
            var value = curve.Evaluate(t / 2);
            Camera.main.orthographicSize = Mathf.Lerp(70f, 50f, value);
            yield return 0;
            t += Time.deltaTime;
        }
    }
	
}
