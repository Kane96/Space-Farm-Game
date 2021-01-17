using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour

{
    public float minZoom;
    public float maxZoom;
    public Camera camera;
    public float moveSpeed;
    public static bool movementLocked = true;
    public static float maxXValue = 1;
    public static float minXValue = -1;
    public static float maxYValue = 1;
    public static float minYValue = -1;

    void Update()
    {
        zoom();
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < maxYValue)
            {
                transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > minYValue)
            {
                transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > minXValue)
            {
                transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < maxXValue)
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    void zoom()
    {
        //mouse scroll down
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !(camera.orthographicSize >= minZoom))
        {
            //zoom out
            camera.orthographicSize += 0.5f;
        }
        //mouse scroll up
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && !(camera.orthographicSize <= maxZoom))
        {
            //zoom in
            camera.orthographicSize -= 0.5f;
        }
    }

}
