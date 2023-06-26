using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class ConfiguratorContainer : MonoBehaviour
    {
        public TypeDisplayContainer TypeDisplayContainer;
        public Configurator Configurator;
        public GameObject MutationsSelectedPanel;

        [Space(20)]
        [Header("Audio")]
        [SerializeField] private AudioClip openStatsPanelSFX;
        [SerializeField] private AudioClip closeStatsPanelSFX;

        // Start is called before the first frame update
        void Start()
        {
            TypeDisplayContainer.Init();
            Configurator.Init();
        }

        public void OpenMutationsSelectedPanel()
        {
            AudioManager.Instance.PlaySFX(openStatsPanelSFX);
            MutationsSelectedPanel.SetActive(true);
        }

        public void CloseMutationsSelectedPanel()
        {
            AudioManager.Instance.PlaySFX(closeStatsPanelSFX);
            MutationsSelectedPanel.SetActive(false);
        }
    }
}