using System.Collections;
using System.Collections.Generic;
using TMPro;
using TooLoo;
using UnityEngine;
using UnityEngine.UI;

namespace ssj12062023
{
    public class VialSlot : MonoBehaviour
    {
        [SerializeField, ReadOnly] private MutationData mutationData;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private ShadowCopy shadowCopy;

        private Sprite emptySlot;

        public MutationData MutationData => mutationData;
        public Image Image => image;
        public TextMeshProUGUI Title => title;

        private void OnEnable()
        {
            emptySlot = image.sprite;
        }

        public void SetData(MutationData data)
        {
            mutationData = data;
            image.sprite = data.Icon;
            title.text = data.Name;

            shadowCopy.SetInfo(this);
        }

        public void ResetSlot()
        {
            mutationData = null;
            title.text = string.Empty;
            image.sprite = emptySlot;

            shadowCopy.Clear();
        }
    }
}