using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using ssj12062023;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] private float cameraMovementSpeed;

    [SerializeField] private RoomAnchors currentAnchor;

    private Vector3 cameraMovementSpeedVectorOnX;
    private Vector3 cameraMovementSpeedVectorOnZ;

    private void Awake()
    {
        cinemachineVirtualCamera.m_Follow = currentAnchor.transform;

        UpdateCameraMoveSpeed();
    }

    private void Update()
    {
        UpdateCameraMoveSpeed();

        MoveCamera();
    }

    private void MoveCamera()
    {
        if (GameManager.Instance.IsGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeRoom(currentAnchor.NorthAnchor);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                ChangeRoom(currentAnchor.WestAnchor);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeRoom(currentAnchor.SouthAnchor);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                ChangeRoom(currentAnchor.EastAnchor);
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

    private void ChangeRoom(RoomAnchors changedRoomAnchor)
    {
        if (changedRoomAnchor)
        {
            currentAnchor = changedRoomAnchor;
            cinemachineVirtualCamera.m_Follow = currentAnchor.transform;
        }
    }
}
