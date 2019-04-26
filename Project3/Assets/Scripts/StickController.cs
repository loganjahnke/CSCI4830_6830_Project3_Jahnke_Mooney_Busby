using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;

    // Update is called once per frame
    void Update()
    {
        if(name == "LeftStick") {
            transform.localRotation = leftController.localRotation;
            transform.Rotate(90, 0, 0, Space.Self);
        }
        else {
            transform.localRotation = rightController.localRotation;
            transform.Rotate(90, 0, 0, Space.Self);
        }
    }
}
