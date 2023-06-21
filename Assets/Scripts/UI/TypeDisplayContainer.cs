using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ssj12062023
{
    public class TypeDisplayContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private List<string> options;

        private int currentIndex;

        public event System.Action OnOptionChanged;
        
        public string CurrentOption => options[currentIndex];

        public void Init()
        {
            currentIndex = 0;
            text.text = options[currentIndex];
        }

        public void OnRightButton()
        {
            currentIndex = Mathf.Clamp(currentIndex + 1, 0, options.Count - 1);
            text.text = options[currentIndex];
            OnOptionChanged?.Invoke();
        }

        public void OnLeftButton()
        {
            currentIndex = Mathf.Clamp(currentIndex - 1, 0, options.Count - 1);
            text.text = options[currentIndex];
            OnOptionChanged?.Invoke();
        }
    }
}