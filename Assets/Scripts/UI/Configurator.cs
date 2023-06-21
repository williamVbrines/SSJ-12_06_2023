using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ssj12062023
{
    public class Configurator : MonoBehaviour, IDropHandler
    {
        public TypeDisplayContainer TypeDisplayContainer;

        private void OnEnable()
        {
            TypeDisplayContainer.OnOptionChanged += ChangeConfiguration;
        }

        private void OnDisable()
        {
            TypeDisplayContainer.OnOptionChanged -= ChangeConfiguration;
        }

        public void Init()
        {

        }

        private void ChangeConfiguration()
        {
            Debug.Log("Configurator configuration changed...");
        }

        public void OnDrop(PointerEventData eventData)
        {

        }
    }
}