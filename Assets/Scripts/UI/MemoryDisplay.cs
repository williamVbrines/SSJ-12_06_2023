using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ssj12062023
{
    public class MemoryDisplay : MonoBehaviour
    {
        [Space(10)]
        [Header("UI Elements")]
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI info;

        public void SetData(MemoryData data)
        {
            title.text = data.Title;
            info.text = data.Description;
        }

        public void ClearData()
        {
            title.text = "Log Entry - -";
            info.text = string.Empty;
        }
    }
}