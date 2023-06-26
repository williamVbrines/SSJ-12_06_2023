using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ssj12062023
{
    [Serializable]
    public struct BodyPartPreview
    {
        public string Name;
        public EMutationType MutationType;
        public EBidirectionality Bidirectionality;
        public Image Image;

        public void Clear()
        {
            Image.sprite = null;
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 0);
        }
    }

    public class CreaturePreview : MonoBehaviour
    {
        [SerializeField] private Configurator configurator;
        [SerializeField] private GameObject statsPanel;

        [Space(20)]
        [Header("Audio")]
        [SerializeField] private AudioClip openStatsPanelSFX;
        [SerializeField] private AudioClip closeStatsPanelSFX;

        [Space(20)]
        [Header("Body Part Previews")]
        [SerializeField] private BodyPartPreview[] previews;

        private void OnEnable()
        {
            configurator.OnAddMutationVial += AddPreview;
            configurator.OnClearConfigurator += ClearPreview;
            configurator.OnRemoveMutationVial += RemovePreview;
        }        

        private void OnDisable()
        {
            configurator.OnAddMutationVial -= AddPreview;
            configurator.OnClearConfigurator -= ClearPreview;
            configurator.OnRemoveMutationVial -= RemovePreview;
        }

        private void AddPreview(MutationData data)
        {
            foreach (BodyPartPreview p in previews)
            {
                if (p.MutationType == data.Type && p.Bidirectionality == data.Bidirectionality)
                {
                    p.Image.sprite = (data as BodyMutationData).BodyPart;
                    p.Image.color = new Color(p.Image.color.r, p.Image.color.g, p.Image.color.b, 1);
                    return;
                }
            }
        }

        private void RemovePreview(MutationData data)
        {
            foreach (BodyPartPreview p in previews)
            {
                if (p.MutationType == data.Type && p.Bidirectionality == data.Bidirectionality)
                {
                    p.Image.sprite = null;
                    p.Image.color = new Color(p.Image.color.r, p.Image.color.g, p.Image.color.b, 0);
                    return;
                }
            }
        }

        private void ClearPreview()
        {
            foreach (BodyPartPreview p in previews)
            {
                p.Clear();
            }
        }

        public void OpenCreatureStatsPanel()
        {
            AudioManager.Instance.PlaySFX(openStatsPanelSFX);
            statsPanel.SetActive(true);
        }

        public void CloseCreatureStatsPanel()
        {
            AudioManager.Instance.PlaySFX(closeStatsPanelSFX);
            statsPanel.SetActive(false);
        }
    }
}