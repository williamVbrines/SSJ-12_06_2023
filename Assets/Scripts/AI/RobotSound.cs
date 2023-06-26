using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class RobotSound : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> audioClips;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private float minDelay = 2f;
        [SerializeField] private float maxDelay = 5f;

        private Coroutine audioCoroutine;
        private bool isPlayingClip;

        private void Start()
        {
            isPlayingClip = false;
            audioCoroutine = StartCoroutine(PlayRandomClip());
        }

        private IEnumerator PlayRandomClip()
        {
            while (true)
            {
                if (!isPlayingClip)
                {
                    // Wait for a random amount of time
                    float delay = Random.Range(minDelay, maxDelay);
                    yield return new WaitForSeconds(delay);

                    // Play a random audio clip from the list
                    int randomIndex = Random.Range(0, audioClips.Count);
                    AudioClip randomClip = audioClips[randomIndex];

                    isPlayingClip = true;
                    audioSource.PlayOneShot(randomClip);

                    yield return new WaitForSeconds(randomClip.length);

                    isPlayingClip = false;
                }
                yield return null;
            }
        }

        private void OnDestroy()
        {
            if (audioCoroutine != null)
                StopCoroutine(audioCoroutine);
        }
    }
}