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
        [ReadOnly] public string CardUID;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private ShadowCopy shadowCopy;

        private Sprite emptySlot;

        public Image Image => image;
        public TextMeshProUGUI Title => title;

        private void OnEnable()
        {
            emptySlot = image.sprite;
            CardUID = string.Empty;
        }

        public void SetData(MutationData data)
        {
            CardUID = data.UID;
            image.sprite = data.Icon;
            title.text = data.Name;

            shadowCopy.SetInfo(this);
        }

        public void ResetSlot()
        {
            CardUID = string.Empty;
            title.text = string.Empty;
            image.sprite = emptySlot;

            shadowCopy.Clear();
        }
    }
}