using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableWelcome : MonoBehaviour {

    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Off);
    }

    public void Off(){
        transform.parent.gameObject.SetActive(false);
    }
}
