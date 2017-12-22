using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Debuger : MonoBehaviour {

    private void Awake()
    {
        StartCoroutine(Fuck());
    }

    IEnumerator Fuck(){
        while (true){
            yield return new WaitForSeconds(1f);
            GetComponent<Text>().text = GameManager.instance.adViewd.ToString();
        }

    }
}
