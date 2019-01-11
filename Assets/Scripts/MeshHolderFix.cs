using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshHolderFix : MonoBehaviour {

    public bool findMeshHolder = false;
    bool isEnable = false;

    public Transform camTransform;
    Transform lastCamTransform;
    GameObject meshHolder;

    void Start()
    {
        lastCamTransform = camTransform;
    }

    // Update is called once per frame
    void Update () {

        if (findMeshHolder)
        {
            meshHolder = GameObject.Find("[ZED Mesh Holder]");
            if (meshHolder == null)
            {
                Debug.Log("Mesh Holder not found");
            }

            lastCamTransform.position = camTransform.position;

            findMeshHolder = false;
            isEnable = true;
        }

        if (isEnable)
        {
            meshHolder.transform.position -= (camTransform.position - lastCamTransform.position);
            print((camTransform.position - lastCamTransform.position).magnitude);
        }
	}
}
