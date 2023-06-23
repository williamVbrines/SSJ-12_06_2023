using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ssj12062023
{
    public class ConfiguratorVialSlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EMutationType mutationType;
        [SerializeField] private GameObject mutationVialSprite;

        private MutationData mutationData;

        public event Action<MutationData> OnRemoveVial;

        public MutationData MutationData => mutationData;
        public EMutationType MutationType => mutationType;
        public bool IsAvailable => mutationData is null;
        public int GeneticCost => mutationData.GeneticCost;

        public void SetData(MutationData data)
        {
            mutationData = data;
            mutationVialSprite.SetActive(true);
        }

        public void Clear()
        {
            mutationData = null;
            mutationVialSprite.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                if (mutationData is null)
                {
                    return;
                }

                OnRemoveVial?.Invoke(mutationData);
                Clear();                
            }
        }
    }
}