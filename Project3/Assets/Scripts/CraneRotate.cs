﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CraneRotate : MonoBehaviour
{
    public GameObject arm;
    public GameObject arm2;
    public GameObject bucket;
    public float vel;
    public Transform leftController;
    public Transform rightController;

	public OVRInput.Controller left;
	public OVRInput.Controller right;

	// Update is called once per frame
	void Update()
    {
		///////////////////////////////////////////////////////////
		//Rift
		///////////////////////////////////////////////////////////
		//move arm down
		Debug.Log("Primary");
		Debug.Log(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick));
		Debug.Log("Secondary");
		Debug.Log(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick));

		if (rightController.localRotation.x > -.6f && arm.transform.localRotation.x < 0.3) {
            arm.transform.Rotate((vel * 0.5f),0,0,Space.Self);
        }
        //move left
        if (leftController.localRotation.z > -0.1) {
            transform.Rotate(0,-(vel * 0.5f), 0,Space.World);
        }
        //move arm up
        if (rightController.localRotation.x < -0.73f && arm.transform.localRotation.x > -0.2) {
            arm.transform.Rotate(-(vel * 0.5f), 0,0,Space.Self);
        }
        //move right
        if (leftController.localRotation.z < -0.25f) {
            transform.Rotate(0, (vel * 0.5f), 0,Space.World);
        }
        //arm2 angle in
        if (leftController.localRotation.x < -.7f && arm2.transform.localRotation.x < 0.5) {
            arm2.transform.Rotate(vel, 0, 0, Space.Self);
        }
        //arm2 angle out
        if (leftController.localRotation.x > -0.6f && arm2.transform.localRotation.x > -0.6) {
            arm2.transform.Rotate(-vel, 0, 0, Space.Self);
        }
        //bucket close
        if (rightController.localRotation.z > -0.1f && bucket.transform.localRotation.x < 0.7) {
            bucket.transform.Rotate(vel, 0, 0, Space.Self);
        }
        //bucket open
        if (rightController.localRotation.z < -0.22f && bucket.transform.localRotation.x > -.65) {
            bucket.transform.Rotate(-vel, 0, 0, Space.Self);
        }

        ///////////////////////////////////////////////////////////
        //VIVE CONTROLLLERS
        /////////////////////////////////////////////////////////// 
        /* //move arm down
        if ((rightController.localRotation.x > -.65f && rightController.localRotation.x < 0.7f) && arm.transform.localRotation.x < 0.3) {
            arm.transform.Rotate((vel * 0.5f),0,0,Space.Self);
        }
        //move left
        if (leftController.localRotation.z > 0.05f) {
            transform.Rotate(0,-(vel * 0.5f), 0,Space.World);
        }
        //move arm up
        if ((rightController.localRotation.x < -.75f || rightController.localRotation.x > 0.7f) && arm.transform.localRotation.x > -0.2) {
            arm.transform.Rotate(-(vel * 0.5f), 0,0,Space.Self);
        }
        //move right
        if (leftController.localRotation.z < -0.07f) {
            transform.Rotate(0, (vel * 0.5f), 0,Space.World);
        }
        //arm2 angle in
        if ((leftController.localRotation.x < -.75f || leftController.localRotation.x > 0.7f) && arm2.transform.localRotation.x < 0.5) {
            arm2.transform.Rotate(vel, 0, 0, Space.Self);
        }
        //arm2 angle out
        if ((leftController.localRotation.x > -.65f && leftController.localRotation.x < 0.7f) && arm2.transform.localRotation.x > -0.6) {
            arm2.transform.Rotate(-vel, 0, 0, Space.Self);
        }
        //bucket close
        if (rightController.localRotation.z > 0.05f && bucket.transform.localRotation.x < 0.7) {
            bucket.transform.Rotate(vel, 0, 0, Space.Self);
        }
        //bucket open
        if (rightController.localRotation.z < -0.07f && bucket.transform.localRotation.x > -.65) {
            bucket.transform.Rotate(-vel, 0, 0, Space.Self);
        }*/
    }
}
