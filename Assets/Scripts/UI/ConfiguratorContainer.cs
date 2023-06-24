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

        // Start is called before the first frame update
        void Start()
        {
            TypeDisplayContainer.Init();
            Configurator.Init();
        }

        public void OpenMutationsSelectedPanel()
        {
            MutationsSelectedPanel.SetActive(true);
        }

        public void CloseMutationsSelectedPanel()
        {
            MutationsSelectedPanel.SetActive(false);
        }
    }
}