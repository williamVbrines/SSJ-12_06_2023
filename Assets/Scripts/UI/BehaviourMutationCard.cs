using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TooLoo;

namespace ssj12062023
{
    public class BehaviourMutationCard : MonoBehaviour
    {
        [SerializeField, ReadOnly] private BehaviourMutationData data;

        private Image image;

        public BehaviourMutationData Data => data;

        private void OnEnable()
        {
            image = GetComponent<Image>();
        }

        public void SetData(BehaviourMutationData data)
        {
            this.data = data;
            image.sprite = data.Icon;
        }
    }
}