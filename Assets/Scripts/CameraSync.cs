using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script synchronize offset of the MainCamera (rendering LeapMotion hands) 
/// and ZEDmini cameras (rendering real physical hands)
/// </summary>
public class CameraSync : MonoBehaviour {

    public Camera leapMotionCamera;
    public Vector3 handOffset;        // The offset between hands - set up manualy

	// Use this for initialization
	void Start () {
        transform.position = leapMotionCamera.transform.position;
        transform.rotation = leapMotionCamera.transform.rotation;
    }

    // Update is called once per frame
    void Update () {
        transform.position = leapMotionCamera.transform.position + handOffset;
        transform.rotation = leapMotionCamera.transform.rotation;
    }
}
