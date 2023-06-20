using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ssj12062023
{
    public class Inventory : MonoBehaviour
    {
        public InventoryTypeDisplayContainer InventoryTypeDisplayContainer;
        public InventoryContentContainer InventoryContentContainer;

        private readonly List<BodyMutationData> availableBodyMutationData = new();

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Init()
        {
            InventoryTypeDisplayContainer.Init();
            InventoryContentContainer.Init();
        }


    }
}