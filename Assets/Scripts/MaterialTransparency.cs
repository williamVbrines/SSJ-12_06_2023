using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTransparency : MonoBehaviour
{
    private bool turnTransparent = false;

    private Material material;

    private Color transparencyChangeColor;

    [SerializeField] private float transparencyChangeAmount = 0.05f;

    [SerializeField] private float makeTransparentTimerMax = 1f;
    [SerializeField] private float makeOpaqueTimerMax = 1f;

    private float makeTransparentTimer = 0f;
    private float makeOpaqueTimer = 0f;

    [SerializeField] private float makeTransparentTimerIncreaseRate = 0.1f;
    [SerializeField] private float makeOpaqueTimerIncreaseRate = 0.1f;

    [SerializeField] private float maxOpacity = .95f;
    [SerializeField] private float minOpacity = 0f;

    private void Awake()
    {
        transparencyChangeColor = new Color(0f, 0f, 0f, transparencyChangeAmount);
        material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if (turnTransparent)
        {
            FadeMaterialInSeconds();
        }
        else if(!turnTransparent && material.color.a < maxOpacity)
        {
            OpacifyMaterialInSeconds();
        }
    }

    private void FadeMaterialInSeconds()
    {
        makeTransparentTimer += makeTransparentTimerIncreaseRate;

        if (makeTransparentTimer >= makeTransparentTimerMax)
        {
            makeTransparentTimer -= makeTransparentTimer;
            FadeMaterial(material);
        }
    }

    private void FadeMaterial(Material faded)
    {
        if (faded.color.a > minOpacity)
        {
            faded.color -= transparencyChangeColor;
        }
    }

    private void OpacifyMaterialInSeconds()
    {
        makeOpaqueTimer += makeOpaqueTimerIncreaseRate;

        if (makeOpaqueTimer >= makeOpaqueTimerMax)
        {
            makeOpaqueTimer -= makeOpaqueTimer;
            OpacifyMaterial(material);
        }
    }

    private void OpacifyMaterial(Material faded)
    {
        if(faded.color.a < maxOpacity)
        {
            faded.color += transparencyChangeColor;
        }
    }

    public void MakeTransparent()
    {
        turnTransparent = true;
    }

    public void MakeOpaque()
    {
        turnTransparent = false;
    }
}
