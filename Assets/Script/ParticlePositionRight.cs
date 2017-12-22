using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePositionRight : MonoBehaviour {
    private void OnEnable()
    {
        transform.localPosition = new Vector3(Screen.width / 2, 0, 0);
    }
}
