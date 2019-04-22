using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneRotate : MonoBehaviour
{
    public GameObject arm;
    public GameObject arm2;
    public GameObject bucket;
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move arm down
        if(Input.GetKey(KeyCode.DownArrow) && arm.transform.localRotation.x < 0.3) {
            Debug.Log(arm.transform.localRotation.x);
            arm.transform.Rotate((vel * 0.5f),0,0,Space.Self);
        }
        //move left
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,-(vel * 0.5f), 0,Space.World);
        }
        //move arm up
        if (Input.GetKey(KeyCode.UpArrow) && arm.transform.localRotation.x > -0.2) {
            Debug.Log(arm.transform.localRotation.x);
            arm.transform.Rotate(-(vel * 0.5f), 0,0,Space.Self);
        }
        //move right
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, (vel * 0.5f), 0,Space.World);
        }
        //arm2 angle in
        if (Input.GetKey(KeyCode.S) && arm2.transform.localRotation.x < 0.5) {
            arm2.transform.Rotate(vel, 0, 0, Space.Self);
        }
        //arm2 angle out
        if (Input.GetKey(KeyCode.W) && arm2.transform.localRotation.x > -0.6) {
            arm2.transform.Rotate(-vel, 0, 0, Space.Self);
        }
        //bucket close
        if (Input.GetKey(KeyCode.LeftArrow) && bucket.transform.localRotation.x < 0.7) {
            bucket.transform.Rotate(vel, 0, 0, Space.Self);
        }
        //bucket open
        if (Input.GetKey(KeyCode.RightArrow) && bucket.transform.localRotation.x > -.65) {
            bucket.transform.Rotate(-vel, 0, 0, Space.Self);
        }
    }
}
