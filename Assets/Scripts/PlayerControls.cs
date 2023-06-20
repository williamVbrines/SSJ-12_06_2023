using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private void Update()
    {
        IngameControls();
    }

    private void IngameControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.IsGameStarted)
        {
            GameManager.Instance.StartPauseGame();
            GameManager.Instance.OpenCloseIngameMenu();
        }
    }
}
