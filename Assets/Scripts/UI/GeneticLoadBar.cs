using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class GeneticLoadBar : MonoBehaviour
    {
        [SerializeField] private Configurator configurator;
        [SerializeField] private int maxLoad = 100;
        
        private int currentLoad;

        private void OnEnable()
        {
            configurator.OnConfigurationChanged += AdjustLoad;
        }

        private void OnDisable()
        {
            configurator.OnConfigurationChanged -= AdjustLoad;
        }

        public void Init()
        {
            currentLoad = 0;
        }

        private void AdjustLoad()
        {
            currentLoad = configurator.GetTotalGeneticCost();

            // Adjust fill bar
            Debug.Log($"Current Genetic Load: {currentLoad}/{maxLoad}");
        }
    }
}