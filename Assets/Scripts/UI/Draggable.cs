using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ssj12062023
{
    public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private float lerpTime = 1f;

        private Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;

        private Vector2 originalPosition;
        private bool isDroppedInValidArea;

        private void Awake()
        {
            canvas = FindObjectOfType<Canvas>();
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            originalPosition = rectTransform.anchoredPosition;
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            if (!isDroppedInValidArea)
            {
                StartCoroutine(ReturnToOriginalPosition());
            }
        }

        private IEnumerator ReturnToOriginalPosition()
        {
            float elapsedTime = 0;           

            while (elapsedTime < lerpTime)
            {
                rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, originalPosition, (elapsedTime / lerpTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Snap to the original position
            rectTransform.anchoredPosition = originalPosition;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Optional: add custom logic for when the card is clicked but not yet dragged
        }

        // Call this function when the card is dropped in a valid area
        public void ValidDropArea()
        {
            isDroppedInValidArea = true;
        }
    }
}