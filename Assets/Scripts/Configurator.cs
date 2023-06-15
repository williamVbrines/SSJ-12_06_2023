using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ssj12062023
{
    public class Configurator : MonoBehaviour, IDropHandler 
    {
        [SerializeField] private GameObject bodyMutationsSlotsArea;
        [SerializeField] private GameObject cardSlot;

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
            if (eventData.pointerDrag != null)
            {
                // Add body mutation to an open slot
            }
        }
    }
}