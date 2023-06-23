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

        [Space(20)]
        [Header("Configurator Vial Slots")]
        [SerializeField] private ConfiguratorVialSlot leftEyeSlot;
        [SerializeField] private ConfiguratorVialSlot rightEyeSlot;
        [SerializeField] private ConfiguratorVialSlot headSlot;
        [SerializeField] private ConfiguratorVialSlot torsoSlot;
        [SerializeField] private ConfiguratorVialSlot leftArmSlot;
        [SerializeField] private ConfiguratorVialSlot rightArmSlot;
        [SerializeField] private ConfiguratorVialSlot leftLegSlot;
        [SerializeField] private ConfiguratorVialSlot rightLegSlot;
        [SerializeField] private ConfiguratorVialSlot tailSlot;
        [SerializeField] private ConfiguratorVialSlot behaviourChipSlot;

        private int currentGeneticLoad;
        private ConfigurationLayoutData currentLayout;

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
                        switch (copy.VialSlot.MutationData.Type)
                        {
                            case EMutationType.Eyes:
                                HandleEyeSlots(copy.VialSlot.MutationData);
                                break;
                            case EMutationType.Head:
                                HandleHeadSlot(copy.VialSlot.MutationData);
                                break;
                            case EMutationType.Torso:
                                
                                break;
                            case EMutationType.Arms:
                                break;
                            case EMutationType.Legs:
                                break;
                            case EMutationType.Tail:
                                break;
                            default:
                                break;
                        }
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

        private void HandleEyeSlots(MutationData data)
        {
            if (leftEyeSlot.IsAvailable)
            {
                leftEyeSlot.SetData(data);
                return;
            }

            if (rightEyeSlot.IsAvailable)
            {
                rightEyeSlot.SetData(data);
                return;
            }
        }

        private void HandleHeadSlot(MutationData data)
        {
            if (headSlot.IsAvailable)
            {
                headSlot.SetData(data);
                return;
            }
        }

        private void HandleTorsoSlot(MutationData data)
        {
            if (torsoSlot.IsAvailable)
            {
                torsoSlot.SetData(data);
                return;
            }
        }

        public int GetTotalGeneticCost()
        {
            int sum = 0;
            

            return sum;
        }

        private bool WillNotExceedMaxGeneticLoad(int geneticCost)
        {
            return currentGeneticLoad + geneticCost <= maxGeneticLoad;
        }

        public CreatureBlueprint SaveCreature()
        {
            CreatureBlueprint blueprint = ScriptableObject.CreateInstance<CreatureBlueprint>();

            

            return blueprint;
        }
    }
}