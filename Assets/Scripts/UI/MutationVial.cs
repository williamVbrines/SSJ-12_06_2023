using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TooLoo;
using TMPro;

namespace ssj12062023
{
    public class MutationVial : MonoBehaviour
    {
        [SerializeField, ReadOnly] private BodyMutationData data;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI title;

        private Sprite originalSprite;

        public BodyMutationData Data => data;

        public void SetData(BodyMutationData data)
        {
            this.data = data;
            title.text = data.Name;
            image.sprite = data.Icon;
        }
    }
}