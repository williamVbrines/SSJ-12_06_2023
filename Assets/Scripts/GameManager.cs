using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject ingameMenu;
    [SerializeField] private GameObject ingameUI;
    [SerializeField] private GameObject creatureCreatorUI;

    private bool isGameStarted = false;
    public bool IsGameStarted { get { return isGameStarted; } }

    private void Awake()
    {
        CreateInstance();

        Time.timeScale = 0f;
    }

    public void StartPauseGame()
    {
        isGameStarted = !isGameStarted;

        if (isGameStarted)
        {
            Time.timeScale = 1;
        }
        else if (!isGameStarted)
        {
            Time.timeScale = 0;
        }
    }

    private void CreateInstance()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ReverseMainMenuState()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCloseIngameMenu()
    {
        ingameMenu.SetActive(!ingameMenu.activeSelf);
    }

    public void ShowHideInGameUI()
    {
        ingameUI.SetActive(!ingameUI.activeSelf);
    }

    public void ExitCreatureCreator()
    {
        creatureCreatorUI.SetActive(false);
    }
}
