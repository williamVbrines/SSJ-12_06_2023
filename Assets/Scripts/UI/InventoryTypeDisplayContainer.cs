using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace ssj12062023
{
    public class InventoryTypeDisplayContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private readonly List<string> options = new();
        private int currentIndex;

        public EBodyPartType CurrentBodyPartType => (EBodyPartType)System.Enum.Parse(typeof(EBodyPartType), options[currentIndex]);

        public event Action OnBodyPartTypeChanged;

        // Start is called before the first frame update
        void Start()
        {
            //Init(); // TODO - Remove this. Call from central place elsewhere.
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Init()
        {
            options.AddRange(new List<string>(System.Enum.GetNames(typeof(EBodyPartType))));
            currentIndex = 2;
            text.text = options[currentIndex];
        }

        public void OnRightButton()
        {
            currentIndex = Mathf.Clamp(currentIndex + 1, 0, options.Count - 1);
            text.text = options[currentIndex];
            OnBodyPartTypeChanged?.Invoke();
        }

        public void OnLeftButton()
        {
            currentIndex = Mathf.Clamp(currentIndex - 1, 0, options.Count - 1);
            text.text = options[currentIndex];
            OnBodyPartTypeChanged?.Invoke();
        }
    }
}