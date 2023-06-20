using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace ssj12062023
{
    public class InventoryContentContainer : MonoBehaviour
    {
        public InventoryTypeDisplayContainer InventoryTypeDisplayContainer;
        public VialSlot[] VialSlots;

        private int displayStartIndex;
        private readonly List<BodyMutationData> availableBodyMutationData = new();

        private void OnEnable()
        {
            InventoryTypeDisplayContainer.OnBodyPartTypeChanged += OnBodyPartTypeChanged;
        }

        private void OnDisable()
        {
            InventoryTypeDisplayContainer.OnBodyPartTypeChanged -= OnBodyPartTypeChanged;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Init()
        {
            displayStartIndex = 0;

            UpdateAvailableBodyMutationData();
            UpdateDisplayedMutationVials();
        }

        private void OnBodyPartTypeChanged()
        {
            displayStartIndex = 0;
            
            UpdateAvailableBodyMutationData();
            UpdateDisplayedMutationVials();
        }

        private void UpdateAvailableBodyMutationData()
        {
            availableBodyMutationData.Clear();
            availableBodyMutationData.AddRange(BodyMutationData.GetAll(InventoryTypeDisplayContainer.CurrentBodyPartType));
        }

        public void UpdateDisplayedMutationVials()
        {
            for (int i = 0; i < VialSlots.Length; i++)
            {
                if (i < availableBodyMutationData.Count)
                {
                    int itemIndex = (displayStartIndex + i) % availableBodyMutationData.Count;
                    VialSlots[i].SetData(availableBodyMutationData[itemIndex]);
                }                
            }
        }

        private void OnRightButton()
        {
            displayStartIndex = (displayStartIndex + 1) % availableBodyMutationData.Count;
            UpdateDisplayedMutationVials();
        }

        private void OnLeftButton()
        {
            displayStartIndex--;
            if (displayStartIndex < 0)
            {
                displayStartIndex = availableBodyMutationData.Count - 1;
            }

            UpdateDisplayedMutationVials();
        }
    }
}