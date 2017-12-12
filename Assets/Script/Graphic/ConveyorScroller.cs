using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScroller : MonoBehaviour {

    public float speed;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = new Vector3(-Time.time * speed, 0, 0);
        rend.material.mainTextureOffset = offset;
	}
}
