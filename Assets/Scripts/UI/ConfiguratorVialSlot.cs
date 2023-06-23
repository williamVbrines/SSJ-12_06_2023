using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ssj12062023
{
    public class ConfiguratorVialSlot : MonoBehaviour
    {
        [SerializeField] private EMutationType mutationType;
        [SerializeField] private GameObject mutationVialSprite;

        private MutationData mutationData;

        public bool IsAvailable => mutationData is null;

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
    }
}