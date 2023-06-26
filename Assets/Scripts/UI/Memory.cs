using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class Memory : MonoBehaviour
    {
        [SerializeField] private MemoryData data;

        public void ActivateMemoryDisplay()
        {
            GameManager.Instance.ShowMemoryDisplay(data);
        }

        public void DeactivateMemoryDisplay()
        {
            GameManager.Instance.CloseMemoryDisplay();
        }
    }
}