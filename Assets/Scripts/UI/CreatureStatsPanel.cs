using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ssj12062023
{
    [Serializable]
    public struct Stat
    {
        public string Name;
        public TextMeshProUGUI Title;
        public TextMeshProUGUI Info;
    }

    public class CreatureStatsPanel : MonoBehaviour
    {
        [SerializeField] private Configurator configurator;
        [SerializeField] private Stat aggression;

        private void OnEnable()
        {
            foreach (ConfiguratorSlot s in configurator.Slots)
            {
                if (s.MutationType == EMutationType.Behaviour)
                {
                    if (s.VialSlot.IsAvailable)
                    {
                        aggression.Info.text = "- - -";
                    }
                    else
                    {
                        aggression.Info.text = (s.VialSlot.MutationData as BehaviourMutationData).Aggression.ToString();
                    }
                    return;
                }
            }
        }
    }
}