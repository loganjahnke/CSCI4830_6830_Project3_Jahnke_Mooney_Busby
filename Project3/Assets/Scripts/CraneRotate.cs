using System.Collections;
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

	private float accel;

	// Update is called once per frame
	void Update()
    {
		///////////////////////////////////////////////////////////
		//Joysticks
		///////////////////////////////////////////////////////////
		//move arm down
		if (-Input.GetAxis("RightVertical") < -0.4 && arm.transform.localRotation.x < 0.3) {
			accel = Input.GetAxis("RightVertical");
			arm.transform.Rotate((accel * vel * 0.5f * 90) * Time.deltaTime, 0,0,Space.Self);
        }
        //move left
        if (-Input.GetAxis("LeftHorizontal") < -0.4) {
			accel = Input.GetAxis("LeftHorizontal");
			transform.Rotate(0,(accel * vel * 0.5f * 90) * Time.deltaTime, 0,Space.World);
        }
        //move arm up
        if (-Input.GetAxis("RightVertical") > 0.4 && arm.transform.localRotation.x > -0.2) {
			accel = Input.GetAxis("RightVertical");
			arm.transform.Rotate((accel * vel * 0.5f * 90) * Time.deltaTime, 0,0,Space.Self);
        }
        //move right
        if (-Input.GetAxis("LeftHorizontal") > 0.4) {
			accel = Input.GetAxis("LeftHorizontal");
			transform.Rotate(0, (accel * vel * 0.5f * 90) * Time.deltaTime, 0,Space.World);
        }
        //arm2 angle in
        if (Input.GetAxis("LeftVertical") > 0.4 && arm2.transform.localRotation.x < 0.5) {
			accel = Input.GetAxis("LeftVertical");
			arm2.transform.Rotate((accel * vel * 90) * Time.deltaTime, 0, 0, Space.Self);
        }
        //arm2 angle out
        if (Input.GetAxis("LeftVertical") < -0.4 && arm2.transform.localRotation.x > -0.6) {
			accel = Input.GetAxis("LeftVertical");
			arm2.transform.Rotate((accel * vel * 90) * Time.deltaTime, 0, 0, Space.Self);
        }
        //bucket close
        if (-Input.GetAxis("RightHorizontal") < -0.4 && bucket.transform.localRotation.x < 0.7) {
			Debug.Log(bucket.transform.localRotation.x);
			accel = Input.GetAxis("RightHorizontal");
			bucket.transform.Rotate((accel * vel * 90) * Time.deltaTime, 0, 0, Space.Self);
        }
        //bucket open
        if (-Input.GetAxis("RightHorizontal") > 0.4 && bucket.transform.localRotation.x > -.65) {
			Debug.Log(bucket.transform.localRotation.x);
			accel = Input.GetAxis("RightHorizontal");
			bucket.transform.Rotate((accel * vel * 90) * Time.deltaTime, 0, 0, Space.Self);
        }

		///////////////////////////////////////////////////////////
		//Rift
		///////////////////////////////////////////////////////////
		//move arm down
		if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y < -0.5 && arm.transform.localRotation.x < 0.3) {
            arm.transform.Rotate((vel * 0.5f),0,0,Space.Self);
        }
        //move left
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < -0.5) {
            transform.Rotate(0,-(vel * 0.5f), 0,Space.World);
        }
        //move arm up
        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y > 0.5 && arm.transform.localRotation.x > -0.2) {
            arm.transform.Rotate(-(vel * 0.5f), 0,0,Space.Self);
        }
        //move right
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0.5) {
            transform.Rotate(0, (vel * 0.5f), 0,Space.World);
        }
        //arm2 angle in
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y < -0.5 && arm2.transform.localRotation.x < 0.5) {
            arm2.transform.Rotate(vel, 0, 0, Space.Self);
        }
        //arm2 angle out
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y > 0.5 && arm2.transform.localRotation.x > -0.6) {
            arm2.transform.Rotate(-vel, 0, 0, Space.Self);
        }
        //bucket close
        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < -0.5 && bucket.transform.localRotation.x < 0.7) {
            bucket.transform.Rotate(vel, 0, 0, Space.Self);
        }
        //bucket open
        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0.5 && bucket.transform.localRotation.x > -.65) {
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
