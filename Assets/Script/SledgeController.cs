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
            transform.eulerAngles -= Vector3.up * Time.deltaTime * speed * Time.time;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.up * Time.deltaTime * speed * Time.time;
        }

        // ONE
        // ONE
       
        if (transform.position.z > 170f)
        {
            StagePosition.instance.starting.SetActive(false);
            StagePosition.instance.CurrentIndex = 0;
        }
        if (transform.position.z > 370f)
        {
            StagePosition.instance.CurrentIndex = 1;
        }
        if (transform.position.z > 570f)
        {
            StagePosition.instance.CurrentIndex = 2;
        }
        if (transform.position.z > 770f)
        {
            StagePosition.instance.CurrentIndex = 3;
        }
        if (transform.position.z > 970f)
        {
            StagePosition.instance.CurrentIndex = 4;
        }
        if (transform.position.z > 1170f)
        {
            StagePosition.instance.CurrentIndex = 5;
        }
        if (transform.position.z > 1370f)
        {
            StagePosition.instance.CurrentIndex = 6;
        }
        if (transform.position.z > 1570f)
        {
            StagePosition.instance.CurrentIndex = 7;
        }
    }
}
