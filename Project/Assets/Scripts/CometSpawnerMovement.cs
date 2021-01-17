using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawnerMovement : MonoBehaviour {

    public GameObject mainCamera;

    private Vector3 cameraTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cameraTransform = mainCamera.transform.position;
        transform.position = new Vector3(cameraTransform.x, cameraTransform.y, 0);
	}
}
