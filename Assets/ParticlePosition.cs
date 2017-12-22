using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePosition : MonoBehaviour {

    private void OnEnable()
    {
        
        transform.localPosition = new Vector3(0, Screen.height / 2, 0);
    }
}
