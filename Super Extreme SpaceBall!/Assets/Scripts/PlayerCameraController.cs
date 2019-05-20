using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
  
    private const float Y_ANGLE_MIN = -15.0f;
    private const float Y_ANGLE_MAX = 20.0f;

    private Transform lookAt;
    private Transform camTransform;
    private Camera cam;

    public float distanceCam = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensX = 4.0f;
    private float sensY = 2.0f;

    private void Start()
    {
        camTransform = GetComponentInChildren<Camera>().transform;
        cam = Camera.main;
        lookAt = GetComponentInChildren<Rigidbody>().transform;
    }

    private void Update()
    {
        if(!LevelManager.isPaused){
            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");
            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
      
    }

    private void LateUpdate()
    {
        if(!LevelManager.isPaused){
            Vector3 dir = new Vector3(0, 5, -distanceCam);
            Quaternion rotation = Quaternion.Euler(-currentY * sensY, currentX * sensX, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);
        }

    }
}
