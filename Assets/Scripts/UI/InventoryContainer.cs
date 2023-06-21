using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ssj12062023
{
    public class InventoryContainer : MonoBehaviour
    {
        public TypeDisplayContainer TypeDisplayContainer;
        public InventoryContentContainer InventoryContentContainer;

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        public void Init()
        {
            TypeDisplayContainer.Init();
            InventoryContentContainer.Init();
        }


    }
}