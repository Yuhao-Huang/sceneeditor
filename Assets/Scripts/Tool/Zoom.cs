using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Zoom : MonoBehaviour
{
    public Camera cam;


    private void Update()
    {
        if (cam.orthographic)
        {
            float newOrthographicSize = cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * 10;
            cam.orthographicSize = Mathf.Max(newOrthographicSize, 1);
        }
        else
        {
            float newFieldOfView = cam.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * 10;
            cam.fieldOfView = Mathf.Max(newFieldOfView, 1);
        }
    }
}

