using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneRotate : MonoBehaviour
{
    public GameObject arm;
    public GameObject arm2;
    public GameObject bucket;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move arm down
        if(Input.GetKey(KeyCode.DownArrow)) {
            arm.transform.Rotate(1,0,0,Space.Self);
        }
        //move left
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,-1,0,Space.World);
        }
        //move arm up
        if (Input.GetKey(KeyCode.UpArrow)) {
            arm.transform.Rotate(-1,0,0,Space.Self);
        }
        //move up
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0,1,0,Space.World);
        }
        //arm2 angle out
        if (Input.GetKey(KeyCode.S)) {
            arm2.transform.Rotate(1, 0, 0, Space.Self);
        }
        //arm2 angle in
        if (Input.GetKey(KeyCode.W)) {
            arm2.transform.Rotate(-1, 0, 0, Space.Self);
        }
        //bucket close
        if (Input.GetKey(KeyCode.LeftArrow)) {
            bucket.transform.Rotate(1, 0, 0, Space.Self);
        }
        //bucket open
        if (Input.GetKey(KeyCode.RightArrow)) {
            bucket.transform.Rotate(-1, 0, 0, Space.Self);
        }
    }
}
