using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move up
        if(Input.GetKey(KeyCode.W)) {
            transform.Rotate(0,0,1,Space.Self);
        }
        //move left
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,-1,0,Space.World);
        }
        //move down
        if (Input.GetKey(KeyCode.S)) {
            transform.Rotate(0,0,-1,Space.Self);
        }
        //move up
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0,1,0,Space.World);
        }
    }
}
