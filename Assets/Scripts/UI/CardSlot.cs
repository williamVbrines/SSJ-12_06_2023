using System.Collections;
using System.Collections.Generic;
using TooLoo;
using UnityEngine;
using UnityEngine.UI;

namespace ssj12062023
{
    public class CardSlot : MonoBehaviour
    {
        [ReadOnly] public string CardUID;

        private Sprite emptySlot;
        private Image image;

        private void OnEnable()
        {
            image = GetComponent<Image>();
            emptySlot = image.sprite;
            CardUID = string.Empty;
        }

        public void UpdateSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }

        public void ResetSprite()
        {
            image.sprite = emptySlot;
        }
    }
}