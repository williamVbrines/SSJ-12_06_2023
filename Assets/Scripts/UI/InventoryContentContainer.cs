using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace ssj12062023
{
    public class InventoryContentContainer : MonoBehaviour
    {
        public TypeDisplayContainer TypeDisplayContainer;
        public VialSlot[] VialSlots;

        private int displayStartIndex;
        private readonly List<MutationData> availableBodyMutationData = new();

        private void OnEnable()
        {
            TypeDisplayContainer.OnOptionChanged += OnBodyPartTypeChanged;
        }

        private void OnDisable()
        {
            TypeDisplayContainer.OnOptionChanged -= OnBodyPartTypeChanged;
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

            if (TypeDisplayContainer.CurrentOption != "Behaviour")
            {
                availableBodyMutationData.AddRange(
                BodyMutationData.GetAll(
                    (EMutationType)System.Enum.Parse(typeof(EMutationType), TypeDisplayContainer.CurrentOption)
                    )
                );
            }
            else
            {
                availableBodyMutationData.AddRange(BehaviourMutationData.GetAll());
            }
        }

        public void UpdateDisplayedMutationVials()
        {
            if (availableBodyMutationData.Count == 0)
            {
                ClearVialSlots();
            }
            else
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
        }

        private void ClearVialSlots()
        {
            for (int i = 0; i < VialSlots.Length; i++)
            {
                VialSlots[i].ResetSlot();
            }
        }

        public void OnRightButton()
        {
            if (availableBodyMutationData.Count == 0 
                || availableBodyMutationData.Count <= VialSlots.Length) return;

            displayStartIndex = (displayStartIndex + 1) % availableBodyMutationData.Count;
            UpdateDisplayedMutationVials();
        }

        public void OnLeftButton()
        {
            if (availableBodyMutationData.Count == 0
                || availableBodyMutationData.Count <= VialSlots.Length) return;

            displayStartIndex--;
            if (displayStartIndex < 0)
            {
                displayStartIndex = availableBodyMutationData.Count - 1;
            }

            UpdateDisplayedMutationVials();
        }
    }
}