using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ssj12062023
{
    [Serializable]
    public struct ConfiguratorSlot
    {
        public string Name;
        public EMutationType MutationType;
        public EBidirectionality Bidirectionality;
        public ConfiguratorVialSlot VialSlot;
    }

    public class Configurator : MonoBehaviour, IDropHandler
    {
        [SerializeField] private TypeDisplayContainer typeDisplayContainer;
        [SerializeField] private int maxGeneticLoad = 100;

        [Space(20)]
        [SerializeField] private ConfiguratorSlot[] configuratorSlots;

        private int currentGeneticLoad;

        public ConfiguratorSlot[] Slots => configuratorSlots;
        public int MaxGeneticLoad => maxGeneticLoad;
        public int CurrentGeneticLoad => currentGeneticLoad;

        public event Action<MutationData> OnAddMutationVial;
        public event Action<MutationData> OnRemoveMutationVial;
        public event Action OnClearConfigurator;

        private void OnEnable()
        {
            typeDisplayContainer.OnOptionChanged += ChangeLayout;
            
            foreach (ConfiguratorSlot s in configuratorSlots)
            {
                s.VialSlot.OnRemoveVial += OnPlayerRemoveVial;
            }
        }

        private void OnDisable()
        {
            typeDisplayContainer.OnOptionChanged -= ChangeLayout;

            foreach (ConfiguratorSlot s in configuratorSlots)
            {
                s.VialSlot.OnRemoveVial -= OnPlayerRemoveVial;
            }
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
                    copy.GetComponent<Draggable>().ValidDropArea();

                    foreach (ConfiguratorSlot s in configuratorSlots)
                    {
                        if (s.MutationType == copy.VialSlot.MutationData.Type 
                            && s.Bidirectionality == copy.VialSlot.MutationData.Bidirectionality)
                        {
                            if (s.VialSlot.IsAvailable)
                            {
                                s.VialSlot.SetData(copy.VialSlot.MutationData);
                                currentGeneticLoad = Mathf.Clamp(currentGeneticLoad + copy.VialSlot.MutationData.GeneticCost, 0, maxGeneticLoad);
                                OnAddMutationVial?.Invoke(copy.VialSlot.MutationData);
                                return;
                            }
                            else
                            {
                                currentGeneticLoad -= s.VialSlot.GeneticCost;
                                s.VialSlot.SetData(copy.VialSlot.MutationData);
                                currentGeneticLoad = Mathf.Clamp(currentGeneticLoad + copy.VialSlot.MutationData.GeneticCost, 0, maxGeneticLoad);
                                OnAddMutationVial?.Invoke(copy.VialSlot.MutationData);
                                return;
                            }                            
                        }
                    }
                }
                else
                {
                    // Notify player that max genetic load can't be exceeded
                    Debug.Log("Cannot add mutation. Max genetic load will be exceeded...");
                }
            }
        }

        private void OnPlayerRemoveVial(MutationData data)
        {
            currentGeneticLoad -= data.GeneticCost;
            OnRemoveMutationVial?.Invoke(data);
        }

        private bool WillNotExceedMaxGeneticLoad(int geneticCost)
        {
            return currentGeneticLoad + geneticCost <= maxGeneticLoad;
        }
        
        public bool IsEmpty()
        {
            foreach (ConfiguratorSlot s in configuratorSlots)
            {
                if (!s.VialSlot.IsAvailable)
                {
                    return false;
                }
            }
            return true;
        }

        public void RestartButton()
        {
            foreach (ConfiguratorSlot s in configuratorSlots)
            {
                s.VialSlot.Clear();
            }

            currentGeneticLoad = 0;
            OnClearConfigurator?.Invoke();
        }
    }
}