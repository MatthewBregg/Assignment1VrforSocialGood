using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotationFromCamera : MonoBehaviour {
    public Camera mainCamera;
    // Use this for initialization

    public Vector3 transformOffset;
	void Start () {
	}
	
	
	void FixedUpdate () {
        float cameraY = mainCamera.transform.rotation.eulerAngles.y;
        Vector3 myRotation = transform.rotation.eulerAngles;
        myRotation.y = cameraY;

        transform.rotation = Quaternion.Euler(myRotation);

        transform.position = mainCamera.transform.position + transformOffset;

        
	}
}
