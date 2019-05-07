using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(name == "LeftStick") {
			this.transform.localEulerAngles = new Vector3(Input.GetAxis("LeftVertical") * -30, this.transform.localEulerAngles.y, Input.GetAxis("LeftHorizontal") * -30);
        }
        else {
			this.transform.localEulerAngles = new Vector3(Input.GetAxis("RightVertical") * -30, this.transform.localEulerAngles.y, Input.GetAxis("RightHorizontal") * -30);
		}
    }
}
