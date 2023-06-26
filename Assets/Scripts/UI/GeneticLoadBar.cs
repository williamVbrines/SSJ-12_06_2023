using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ssj12062023
{
    public class GeneticLoadBar : MonoBehaviour
    {
        [SerializeField] private Configurator configurator;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Slider fillBar;

        private void OnEnable()
        {
            configurator.OnAddMutationVial += AdjustLoad;
            configurator.OnRemoveMutationVial += AdjustLoad;
            configurator.OnClearConfigurator += ResetBar;
        }

        private void OnDisable()
        {
            configurator.OnAddMutationVial -= AdjustLoad;
            configurator.OnRemoveMutationVial -= AdjustLoad;
            configurator.OnClearConfigurator -= ResetBar;
        }

        public void Init()
        {
            fillBar.value = 0;
        }

        private void AdjustLoad(MutationData data)
        {
            fillBar.value = configurator.CurrentGeneticLoad;
            text.text = $"Genetic Load: {configurator.CurrentGeneticLoad}/{configurator.MaxGeneticLoad}";
        }

        private void ResetBar()
        {
            fillBar.value = 0;
            text.text = $"Genetic Load: 0/{configurator.MaxGeneticLoad}";
        }
    }
}