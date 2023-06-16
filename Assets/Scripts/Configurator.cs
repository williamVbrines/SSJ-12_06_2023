using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ssj12062023
{
    public class Configurator : MonoBehaviour, IDropHandler 
    {
        [SerializeField] private GameObject bodyMutationsSlotsArea;
        [SerializeField] private GameObject behaviourMutationSlot;

        private BodyMutationData baseBodyMutation;
        private BehaviourMutationData behaviourMutation;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnDrop(PointerEventData eventData)
        {
            BodyMutationCard bodyMutationCard;
            BehaviourMutationCard behaviourMutationCard;
            if (eventData.pointerDrag != null)
            {
                if (eventData.pointerDrag.TryGetComponent<BodyMutationCard>(out bodyMutationCard))
                {
                    if (baseBodyMutation is null)
                    {
                        baseBodyMutation = bodyMutationCard.Data;

                        // Update Configurator UI to display base slots
                        Debug.Log("Base slots displayed...");

                        // Send shadow card back to original position
                        bodyMutationCard.GetComponent<Draggable>().ValidDropArea();
                        
                        // Update genetic load 
                        Debug.Log("Genetic load updated...");
                    }
                    else
                    {
                        // Add mutation to next available slot
                        // Update genetic load
                    }
                }
                else if (eventData.pointerDrag.TryGetComponent<BehaviourMutationCard>(out behaviourMutationCard))
                {
                    behaviourMutation = behaviourMutationCard.Data;
                    
                    // Update Configurator UI to display behavior mutation card
                    Debug.Log("Behaviour mutation set...");
                    
                    // Send shadow card back to original position
                    behaviourMutationCard.GetComponent<Draggable>().ValidDropArea();
                    
                    // Update genetic load
                    Debug.Log("Genetic load updated...");
                }
            }
        }
    }
}