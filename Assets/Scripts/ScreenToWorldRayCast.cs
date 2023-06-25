using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssj12062023;

public class ScreenToWorldRayCast : MonoBehaviour
{
    private Ray screenToWorldRay;

    private Camera mainCamera;

    private Transform selectedTransform;
    public Transform SelectedTransform { get { return selectedTransform; } }

    private int layerMask;

    private string creatureCreatorOpenerTag = "CreatureCreatorOpener";

    private void Awake()
    {
        mainCamera = Camera.main;
        layerMask = 1 << 6;
        layerMask = ~layerMask;
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

            if (Physics.Raycast(screenToWorldRay, out RaycastHit hit, 500f, layerMask))
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
        if (GameManager.Instance.IsGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && CastRay(out selectedTransform))
            {
                if(selectedTransform.tag == creatureCreatorOpenerTag)
                {
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.CreatureCreatorOpenSFX);
                    GameManager.Instance.ShowCreatureCreator();
                }

                Debug.Log(SelectedTransform);
            }
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
