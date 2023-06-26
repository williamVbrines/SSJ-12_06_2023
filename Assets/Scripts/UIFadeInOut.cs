using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeInOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    private bool isClosing = false;

    private void Update()
    {
        if (isClosing)
        {
            UIFadeIn();
        }
        else if(!isClosing)
        {
            UIFadeOut();
        }
    }

    private void UIFadeOut()
    {
        if (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;

            if (canvasGroup.alpha <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void UIFadeIn()
    {
        if (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 2;
        }
    }

    public void FadeUI()
    {
        if (!isClosing)
        {
            gameObject.SetActive(true);
            isClosing = true;
        }
        else if (isClosing)
        {
            isClosing = false;
        }
    }
}
