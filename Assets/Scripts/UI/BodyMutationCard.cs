using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TooLoo;

namespace ssj12062023
{
    public class BodyMutationCard : MonoBehaviour
    {
        [SerializeField, ReadOnly] private BodyMutationData data;

        private Image image;

        public BodyMutationData Data => data;

        private void OnEnable()
        {
            image = GetComponent<Image>();
        }

        public void SetData(BodyMutationData data)
        {
            this.data = data;
            image.sprite = data.Icon;
        }
    }
}