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

        private Sprite emptySlot;

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
        }

        public void ResetSprite()
        {
            CardUID = string.Empty;
            image.sprite = emptySlot;
        }
    }
}