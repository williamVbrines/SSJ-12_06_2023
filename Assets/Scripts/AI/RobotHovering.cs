using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class RobotHovering : MonoBehaviour
    {
        [SerializeField] private Transform modelPrefab; // Reference to the model prefab child
        [SerializeField] private float floatHeight = 3f;   // The maximum height for floating
        [SerializeField] private float floatSpeed = 2f;    // The speed of floating
        [SerializeField] private float floatDuration = 1f; // The duration of each floating cycle

        private Vector3 originalPosition;

        private void Start()
        {
            originalPosition = modelPrefab.localPosition;

            // Start the floating animation loop
            StartCoroutine(FloatingAnimation());
        }

        private IEnumerator FloatingAnimation()
        {
            while (true)
            {
                // Calculate the target position for floating up
                Vector3 targetPositionUp = originalPosition + new Vector3(0f, floatHeight, 0f);

                // Use LeanTween to move the model prefab child up and down
                LTDescr tweenUp = LeanTween.moveLocal(modelPrefab.gameObject, targetPositionUp, floatDuration)
                    .setEase(LeanTweenType.easeInOutCubic);
                LTDescr tweenDown = LeanTween.moveLocal(modelPrefab.gameObject, originalPosition, floatDuration)
                    .setEase(LeanTweenType.easeInOutCubic);

                // Chain the tweens together to create the floating effect
                tweenUp.setOnComplete(tween => tweenDown.resume()).setOnCompleteOnStart(true);
                tweenDown.setOnComplete(tween => tweenUp.resume()).setOnCompleteOnStart(true);

                // Wait for the floating duration
                yield return new WaitForSeconds(floatDuration * 2f);
            }
        }
    }
}