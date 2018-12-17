using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySpatialMappingHelper : MonoBehaviour {

    public bool startMappingFromStart = true;
    public bool displayMeshFromStart = true;
    public ZEDSpatialMappingManager zMng;

    // Use this for initialization
    void Start()
    {
        if (startMappingFromStart)
        {
            Invoke("zMng.StartSpatialMapping", 3f);
        }
        Invoke("zMng.SwitchDisplayMeshState(displayMeshFromStart)", 3.2f);
    }
}
