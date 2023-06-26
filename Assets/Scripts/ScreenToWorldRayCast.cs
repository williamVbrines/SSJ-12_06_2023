using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class ScreenToWorldRayCast : MonoBehaviour
    {
        private Ray screenToWorldRay;

        private Camera mainCamera;

        private Transform selectedTransform;
        public Transform SelectedTransform { get { return selectedTransform; } }

        private int layerMask;

        private string creatureCreatorOpenerTag = "CreatureCreatorOpener";
        private string memoryTag = "Memory";

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

        private Transform CastRay()
        {
            if (!IsMouseOverUI())
            {
                screenToWorldRay = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(screenToWorldRay, out RaycastHit hit, 500f, layerMask))
                {
                    return hit.transform;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void SelectHitTransform()
        {
            if (GameManager.Instance.IsGameStarted)
            {
                Transform hoverOverTransform = CastRay();
                if (hoverOverTransform?.tag == creatureCreatorOpenerTag
                    || hoverOverTransform?.tag == memoryTag)
                {
                    CustomCursor.Instance.UseSelectableCursor();
                }
                else
                {
                    CustomCursor.Instance.UseDefaultCursor();
                }

                if (Input.GetKeyDown(KeyCode.Mouse0) && hoverOverTransform != null)
                {
                    selectedTransform = hoverOverTransform;

                    if (selectedTransform.tag == creatureCreatorOpenerTag)
                    {
                        GameManager.Instance.SignalOpenCreatureCreator();
                    }

                    if (selectedTransform.tag == memoryTag)
                    {
                        GameManager.Instance.SignalActivateMemory(selectedTransform);
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
}