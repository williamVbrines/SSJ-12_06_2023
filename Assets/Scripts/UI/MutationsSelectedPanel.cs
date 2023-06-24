using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ssj12062023
{
    [Serializable]
    public struct MutationInfo
    {
        public TextMeshProUGUI Title;
        public TextMeshProUGUI Info;
    }

    public class MutationsSelectedPanel : MonoBehaviour
    {
        [SerializeField] private Configurator configurator;
        [SerializeField] private MutationInfo[] infos;

        private void OnEnable()
        {
            for (int i = 0; i < infos.Length; i++)
            {
                ConfiguratorSlot configuratorSlot = configurator.Slots[i];
                MutationInfo info = infos[i];

                info.Title.text = configuratorSlot.Name;
                if (configuratorSlot.VialSlot.IsAvailable)
                {                    
                    info.Info.text = "- - -";
                }
                else
                {
                    info.Info.text = configuratorSlot.VialSlot.MutationData.Name;
                }
            }
        }
    }
}