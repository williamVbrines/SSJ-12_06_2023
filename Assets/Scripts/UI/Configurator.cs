using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ssj12062023
{
    public class Configurator : MonoBehaviour, IDropHandler
    {
        [SerializeField] private TypeDisplayContainer typeDisplayContainer;
        [SerializeField] private int maxGeneticLoad = 100;

        private readonly List<VialSlot> bodyMutationSlots = new();
        private VialSlot behaviourChipSlot;

        private int currentGeneticLoad;
        private ConfigurationLayoutData currentLayout;
        private Image image;

        public event Action OnConfigurationChanged;

        private void OnEnable()
        {
            typeDisplayContainer.OnOptionChanged += ChangeLayout;
        }

        private void OnDisable()
        {
            typeDisplayContainer.OnOptionChanged -= ChangeLayout;
        }

        public void Init()
        {

        }

        private void ChangeLayout()
        {
            currentLayout = ConfigurationLayoutData.GetByName(typeDisplayContainer.CurrentOption);

            if (currentLayout != null)
            {
                image.sprite = currentLayout.Sprite;
                currentGeneticLoad = 0;

                OnConfigurationChanged?.Invoke();
                return;
            }

            Debug.LogError($"No configuration layout with the name: {typeDisplayContainer.CurrentOption}");            
        }

        public void OnDrop(PointerEventData eventData)
        {
            // Send shadow copy back to vial slot
            ShadowCopy copy;
            if (eventData.pointerDrag.TryGetComponent<ShadowCopy>(out copy))
            {
                if (copy.VialSlot is null)
                {
                    Debug.Log("Attempting to drop empty vial into configurator!");
                    return;
                }

                if (WillNotExceedMaxGeneticLoad(copy.VialSlot.MutationData.GeneticCost))
                {

                    // TODO - Handle check if slots are available

                    copy.GetComponent<Draggable>().ValidDropArea();

                    if (copy.VialSlot.MutationData.Type == EMutationType.Behaviour)
                    {
                        // Set behaviour chip data 
                        // Add behaviour chip sprite to configurator sprite
                    }
                    else
                    {
                        // Handle logic to place data onto correct slot on configurator
                    }

                    OnConfigurationChanged?.Invoke();
                    Debug.Log("Added mutation to configurator...");
                }
                else
                {
                    // Notify player that max genetic load can't be exceeded
                    Debug.Log("Cannot add mutation. Max genetic load will be exceeded...");
                }
            }
        }

        public int GetTotalGeneticCost()
        {
            int sum = 0;
            foreach (VialSlot s in bodyMutationSlots)
            {
                sum += s.MutationData.GeneticCost;
            }

            return sum;
        }

        private bool WillNotExceedMaxGeneticLoad(int geneticCost)
        {
            return currentGeneticLoad + geneticCost <= maxGeneticLoad;
        }

        public CreatureBlueprint SaveCreature()
        {
            CreatureBlueprint blueprint = ScriptableObject.CreateInstance<CreatureBlueprint>();

            blueprint.Name = "TODO - Get name from user input";
            blueprint.BehaviourMutation = behaviourChipSlot.MutationData.UID;
            
            foreach (VialSlot s in bodyMutationSlots)
            {
                blueprint.BodyMutations.Add(s.MutationData.UID);
            }

            return blueprint;
        }
    }
}