using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TooLoo;

namespace ssj12062023
{

    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject ingameMenu;
        [SerializeField] private GameObject ingameUI;
        [SerializeField] private GameObject creatureCreatorUI;

        [Header("Audio")]
        [SerializeField] private AudioClip openCreatureCreatorSFX;
        [SerializeField] private AudioClip closeCreatureCreatorSFX;

        public event Action OnClickCreatureCreator;
        public event Action OnCloseCreatureCreator;

        private bool isGameStarted = false;
        public bool IsGameStarted { get { return isGameStarted; } }

        protected override void Awake()
        {
            base.Awake();
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
            AudioManager.Instance.PlaySFX(closeCreatureCreatorSFX);
            creatureCreatorUI.SetActive(false);
            OnCloseCreatureCreator?.Invoke();
        }

        public void SignalOpenCreatureCreator()
        {
            OnClickCreatureCreator?.Invoke();
        }

        public void ShowCreatureCreator()
        {
            AudioManager.Instance.PlaySFX(openCreatureCreatorSFX);
            creatureCreatorUI.SetActive(true);
        }
    }
}