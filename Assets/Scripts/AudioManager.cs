using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TooLoo;

namespace ssj12062023
{
    public class AudioManager : Singleton<AudioManager>
    {
        private AudioSource audioSource;

        [SerializeField] private Camera mainCamera;

        [SerializeField] private AudioClip titleLoop;
        [SerializeField] private AudioClip mainLoop;
        [SerializeField] private AudioClip creatureCreatorOpenSFX;
        [SerializeField] private AudioClip saveFailedSFX;
        [SerializeField] private AudioClip saveSuccessSFX;
        [SerializeField] private AudioClip mutationDragBeginSFX;
        [SerializeField] private AudioClip mutationDropFailSFX;
        [SerializeField] private AudioClip mutationDropSuccesSFX;

        public AudioClip TitleLoop { get { return titleLoop; } }
        public AudioClip MainLoop { get { return mainLoop; } }
        public AudioClip CreatureCreatorOpenSFX { get { return creatureCreatorOpenSFX; } }
        public AudioClip SaveFailedSFX { get { return saveFailedSFX; } }
        public AudioClip SaveSuccessSFX { get { return saveSuccessSFX; } }
        public AudioClip MutationDragBeginSFX { get { return mutationDragBeginSFX; } }
        public AudioClip MutationDropFailSFX { get { return mutationDropFailSFX; } }
        public AudioClip MutationDropSuccesSFX { get { return mutationDropSuccesSFX; } }

        protected override void Awake()
        {
            base.Awake();
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            transform.position = mainCamera.transform.position;
        }


        public void VolumeUp()
        {
            audioSource.volume += 0.1f;
        }

        public void VolumeDown()
        {
            audioSource.volume -= 0.1f;
        }

        public void ChangeToMainLoop()
        {
            audioSource.clip = mainLoop;
            audioSource.Play();
        }

        public void PlaySFX(AudioClip playedSFX)
        {
            audioSource.PlayOneShot(playedSFX);
        }
    }
}