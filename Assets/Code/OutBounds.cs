using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OutBounds : MonoBehaviour
{

    private Vector2 startingPosition;
    private Camera mainCamera;
    private Transform spaceshipTransform;
    private Vector3 offset = new Vector3(1.55f, -0.3f, 0f); // Offset for the object above the spaceship

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        mainCamera = Camera.main;

        GameObject spaceshipObject = GameObject.FindGameObjectWithTag("Spaceship");
        if (spaceshipObject != null)
        {
            spaceshipTransform = spaceshipObject.transform;
        }
        else
        {
            Debug.LogError("No game object with tag 'Spaceship' found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //CheckIfOutsideCameraView();

        if (spaceshipTransform != null)
        {
            UpdatePositionAboveSpaceship();
        }
    }
        void UpdatePositionAboveSpaceship()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        bool isOutsideView = (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1);


        if (isOutsideView)
            {
                Debug.Log("Object is outside camera view: " + gameObject.name);
                transform.position = spaceshipTransform.position + offset;
            }
    }
}

