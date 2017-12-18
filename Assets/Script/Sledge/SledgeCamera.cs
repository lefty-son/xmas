using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledgeCamera : MonoBehaviour {


    public Transform target;

    public float speed;

    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothPosition;

        transform.LookAt(target);
    }
}
