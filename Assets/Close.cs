using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close : MonoBehaviour {

    private Button btn;

	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(CloseButton);
		
	}

    public void CloseButton(){
        transform.parent.gameObject.SetActive(false);
    }
	
	
}
