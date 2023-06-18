using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraMovementSpeed;
    
    private Vector3 cameraMovementSpeedVectorOnX;
    private Vector3 cameraMovementSpeedVectorOnZ;

    private void Awake()
    {
        UpdateCameraMoveSpeed();
    }

    private void Update()
    {
        UpdateCameraMoveSpeed();

        MoveCamera();
    }

    private void MoveCamera()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += cameraMovementSpeedVectorOnZ * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -cameraMovementSpeedVectorOnX * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -cameraMovementSpeedVectorOnZ * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += cameraMovementSpeedVectorOnX * Time.deltaTime;
            }
        }
    }

    private void UpdateCameraMoveSpeed()
    {
        if(cameraMovementSpeed != cameraMovementSpeedVectorOnX.x)
        {
            cameraMovementSpeedVectorOnX = new Vector3(cameraMovementSpeed, 0f, 0f);
            cameraMovementSpeedVectorOnZ = new Vector3(0f, 0f, cameraMovementSpeed);
        }
    }
}
