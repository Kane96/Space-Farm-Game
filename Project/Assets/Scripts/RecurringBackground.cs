using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecurringBackground : MonoBehaviour {

    public GameObject background;

    public Vector3 xPositive;

    int xPositiveIncrement = 1;
    int xNegative = -1;
    int yPositive = 1;
    int yNegative = -1;

    int xOffset = 45;
    int yOffset = 26;

    private GameObject newDeco;

    private void Start()
    {
        xPositive = new Vector3(-633.26f, -287.59f, -9.589462f);
    }

    void Update () {
		if (CameraMovement.maxXValue > xPositiveIncrement)
        {
            xPositive = new Vector3(xPositive.x + xOffset, xPositive.y, xPositive.z);
            newDeco = Instantiate(background, xPositive, Quaternion.identity) as GameObject;
            newDeco.transform.SetParent(transform, false);
            print("Spawned");
            xPositiveIncrement += 22;
        }
	}
}
