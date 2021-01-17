using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

    public BoxCollider2D coll;
    private Vector3 mousePos;

	// Use this for initialization
	void Start () {
        coll = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        if (coll.bounds.Contains(mousePos))
        {
            print("I love Fee");
        }
    }
}
