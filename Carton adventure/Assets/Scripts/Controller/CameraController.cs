using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;
    public float distanceIn2D;
    public float heightOffset;

    private DimensionTransformation dt;

    void Start() {
        dt = new DimensionTransformation(player, distanceIn2D,heightOffset);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) 
            Config.IS_3D = true;
        if (Input.GetKeyUp(KeyCode.Space))
            Config.IS_3D = false;
        dt.Update();
    }    
}
