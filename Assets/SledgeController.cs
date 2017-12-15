using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledgeController : MonoBehaviour {
    private Rigidbody rigid;
    public float speed;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Time.time, Space.Self );
        if(Input.GetKey(KeyCode.A)){
            transform.eulerAngles -= Vector3.up * Time.deltaTime * 50;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.up * Time.deltaTime * 50;
        }
        Debug.Log(transform.position.z);


        // ONE
        // ONE
       
        if (transform.position.z > 150f)
        {
            StagePosition.instance.starting.SetActive(false);
            StagePosition.instance.CurrentIndex = 0;
        }
        if (transform.position.z > 350f)
        {
            StagePosition.instance.CurrentIndex = 1;
        }
        if (transform.position.z > 550f)
        {
            StagePosition.instance.CurrentIndex = 2;
        }
        if (transform.position.z > 750f)
        {
            StagePosition.instance.CurrentIndex = 3;
        }
        if (transform.position.z > 950f)
        {
            StagePosition.instance.CurrentIndex = 4;
        }
        if (transform.position.z > 1150f)
        {
            StagePosition.instance.CurrentIndex = 5;
        }
        if (transform.position.z > 1350f)
        {
            StagePosition.instance.CurrentIndex = 6;
        }
        if (transform.position.z > 1550f)
        {
            StagePosition.instance.CurrentIndex = 7;
        }
    }
}
