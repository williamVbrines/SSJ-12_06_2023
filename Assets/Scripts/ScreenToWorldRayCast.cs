using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToWorldRayCast : MonoBehaviour
{
    private Ray screenToWorldRay;

    private Camera mainCamera;

    private Transform selectedTransform;
    public Transform SelectedTransform { get { return selectedTransform; } }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        SelectHitTransform();
    }

    private Transform CastRay(out Transform hitTransform)
    {
        if (!IsMouseOverUI())
        {
            screenToWorldRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(screenToWorldRay, out RaycastHit hit))
            {
                hitTransform = hit.transform;
                return hit.transform;
            }
            else
            {
                hitTransform = null;
                return null;
            }
        }
        else
        {
            hitTransform = null;
            return null;
        }
    }

    private void SelectHitTransform()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && CastRay(out selectedTransform))
        {
            Debug.Log(SelectedTransform);
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
