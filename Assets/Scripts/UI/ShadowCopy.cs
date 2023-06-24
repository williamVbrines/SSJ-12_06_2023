using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ssj12062023
{
    public class ShadowCopy : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private Image image;

        private VialSlot vialSlot;
        private Sprite emptySlot;

        public VialSlot VialSlot => vialSlot;

        private void OnEnable()
        {
            emptySlot = image.sprite;
        }

        public void SetInfo(VialSlot vialSlot)
        {
            this.vialSlot = vialSlot;
            title.text = vialSlot.Title.text;
            image.sprite = vialSlot.Image.sprite;
            Utils.SetAlpha(image, 1);
        }

        public void Clear()
        {
            this.vialSlot = null;
            title.text = string.Empty;
            image.sprite = emptySlot;
            Utils.SetAlpha(image, 0);
        }
    }
}