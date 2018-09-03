using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 120f;

    // Update is called once per frame
    void Update ()
    {
        
        //Store our current camera position
        Vector3 cameraPosition = transform.position;

        //Collect movement input from keys
        if (Input.GetKey("w"))
        {
            cameraPosition.z += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            cameraPosition.z -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            cameraPosition.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            cameraPosition.x -= panSpeed * Time.deltaTime;
        }

        //Collect scroll movement
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cameraPosition.y -= scroll * scrollSpeed * Time.deltaTime;
        cameraPosition.z += scroll * scrollSpeed * Time.deltaTime;

        //Apply our movement changes to camera
        transform.position = cameraPosition;

    }
}
