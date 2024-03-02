using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjustment : MonoBehaviour
{

    void Start()
    {
        float targetAspect = 16.0f / 9.0f;
     
        float windowAspect = (float)Screen.width / (float)Screen.height;
      
        float aspectRatioDifference = targetAspect / windowAspect;
        
        Camera camera = GetComponent<Camera>();

        camera.fieldOfView *= aspectRatioDifference;
    }

    void Update()
    {
        
    }
}
