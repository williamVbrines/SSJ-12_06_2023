using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidScreenToWorldRayCast : MonoBehaviour
{
    private Camera mainCamera;

    private Transform lastHitRoof;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        ChangeTransparency();
    }

    private void ChangeTransparency()
    {
        if (GameManager.Instance.IsGameStarted)
        {
            Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hitRoof, 500f);

            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 500, Color.red);

            if (lastHitRoof != hitRoof.transform)
            {
                if (lastHitRoof && lastHitRoof.transform.TryGetComponent<MaterialTransparency>(out MaterialTransparency materialTransparencyOpaque))
                {
                    materialTransparencyOpaque.MakeOpaque();
                }

                lastHitRoof = hitRoof.transform;

                if (lastHitRoof.transform.TryGetComponent<MaterialTransparency>(out MaterialTransparency materialTransparency))
                {
                    materialTransparency.MakeTransparent();
                }
            }
        }
    }
}
