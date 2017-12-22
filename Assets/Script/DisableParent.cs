using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableParent : MonoBehaviour {

    private Button btn;
    public GameObject hurray;

    private void OnEnable()
    {
        UIManager.instance.Bye();
        hurray.SetActive(true);
    }

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    public void Click(){
        hurray.SetActive(false);
        GameManager.instance.EarnHeart(3);
        transform.parent.gameObject.SetActive(false);
    }
}
