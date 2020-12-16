using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Our player position
    public Transform target;
    //How smooth the camera should be
    public float smoothing;

    //This is the bounds set for camera
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called every fixed frame rate frame
    void FixedUpdate()
    {

        //Get out target position in 2D space, keep z unchanged
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        //Set the bounds for camera
        targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

        //Move the camera smoothly towards player
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);


    }
}
