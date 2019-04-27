using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5;

    private Rigidbody rig;
    // Start is called before the first frame update
    void Start() {
        rig = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector3 movement;
        if (Config.IS_3D)
            movement = Vector3.Normalize(new Vector3(moveV, 0, -moveH));
        else
            movement = new Vector3(moveH, 0, 0);
        rig.AddForce(movement * speed);
    }
}
