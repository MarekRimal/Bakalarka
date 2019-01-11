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

    GameObject meshHolder;

    // Use this for initialization
    void Start () {
        transform.position = leapMotionCamera.transform.position;
        transform.rotation = leapMotionCamera.transform.rotation;

        meshHolder = GameObject.Find("[ZED Mesh Holder]");
        if (meshHolder == null)
        {
            Debug.Log("Mesh Holder not found");
        }
    }

    // Update is called once per frame
    void Update () {

        if (meshHolder == null)
        {
            meshHolder = GameObject.Find("[ZED Mesh Holder]");

        }

        meshHolder.transform.position = (leapMotionCamera.transform.position);

        transform.position = leapMotionCamera.transform.position + handOffset;
        transform.rotation = leapMotionCamera.transform.rotation;
    }
}
