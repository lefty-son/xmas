using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePosition : MonoBehaviour {

    private void OnEnable()
    {
        Debug.Log(Screen.height);
        transform.localPosition = new Vector3(0, Screen.height / 2, 0);
    }
}
