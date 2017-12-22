using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAlpha : MonoBehaviour {

    private MeshRenderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
        rend.material.color = new Color(1f, 1f, 1f, 0f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
