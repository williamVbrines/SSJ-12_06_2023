using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject ingameMenu;

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
}
