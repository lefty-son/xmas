using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloOnner : MonoBehaviour {

    private void OnDisable()
    {
        UIManager.instance.Hello();
    }
}
