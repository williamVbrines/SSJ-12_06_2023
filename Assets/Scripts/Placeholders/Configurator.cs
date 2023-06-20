using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ssj12062023
{
    public class Configurator : MonoBehaviour //, IDropHandler 
    {
        //[SerializeField] private GameObject bodyMutationsSlotsArea;
        //[SerializeField] private VialSlot behaviourMutationCardSlot;

        //[Space(20)]

        //[Header("Prefabs")]
        //[SerializeField] private VialSlot cardSlotPrefab;

        //private BodyMutationData baseBodyMutation;
        //private BehaviourMutationData selectedBehaviourMutation;

        //private readonly List<VialSlot> bodyMutationSlots = new();
        //private readonly List<BodyMutationData> selectedBodyMutations = new();

        //// Start is called before the first frame update
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}

        //public void OnDrop(PointerEventData eventData)
        //{
        //    MutationVial bodyMutationCard;
        //    BehaviourMutationCard behaviourMutationCard;
        //    if (eventData.pointerDrag != null)
        //    {
        //        if (eventData.pointerDrag.TryGetComponent<MutationVial>(out bodyMutationCard))
        //        {
        //            if (baseBodyMutation is null)
        //            {
        //                // Send shadow card back to original position
        //                bodyMutationCard.GetComponent<Draggable>().ValidDropArea();

        //                baseBodyMutation = bodyMutationCard.Data;

        //                // Add base mutation to list
        //                selectedBodyMutations.Clear();
        //                selectedBodyMutations.Add(baseBodyMutation);

        //                // Update Configurator UI to display base slots
        //                GenerateCardSlots(baseBodyMutation.BodyPart.AnchorPointsCount);

        //                // Update genetic load 
        //                Debug.Log("Genetic load updated...");
        //            }
        //            else
        //            {
        //                // Add mutation to next available slot
        //                foreach (VialSlot slot in bodyMutationSlots)
        //                {
        //                    if (slot.CardUID.Equals(string.Empty) && bodyMutationCard.Data.UID != baseBodyMutation.UID)
        //                    {
        //                        bodyMutationCard.GetComponent<Draggable>().ValidDropArea();

        //                        // Store card Id and update sprite of card slot
        //                        slot.CardUID = bodyMutationCard.Data.UID;
        //                        slot.UpdateSprite(bodyMutationCard.Data.Icon);
        //                        selectedBodyMutations.Add(bodyMutationCard.Data);
        //                        break;
        //                    }
        //                }

        //                // Update genetic load
        //                Debug.Log("Genetic load updated...");
        //            }
        //        }
        //        else if (eventData.pointerDrag.TryGetComponent<BehaviourMutationCard>(out behaviourMutationCard))
        //        {
        //            // Send shadow card back to original position
        //            behaviourMutationCard.GetComponent<Draggable>().ValidDropArea();
                    
        //            // Update Configurator UI to display behavior mutation card
        //            selectedBehaviourMutation = behaviourMutationCard.Data;
        //            behaviourMutationCardSlot.CardUID = behaviourMutationCard.Data.UID;
        //            behaviourMutationCardSlot.UpdateSprite(behaviourMutationCard.Data.Icon);

        //            // Update genetic load
        //            Debug.Log("Genetic load updated...");
        //        }
        //    }

        //}

        //private void GenerateCardSlots(int count)
        //{
        //    bodyMutationSlots.Clear();
        //    for (int i = 0; i < count; i++)
        //    {
        //        VialSlot slot = Instantiate<VialSlot>(cardSlotPrefab, bodyMutationsSlotsArea.transform);
        //        bodyMutationSlots.Add(slot);
        //    }
        //}
    }
}