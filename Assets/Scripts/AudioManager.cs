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

        public AudioClip TitleLoop { get { return titleLoop; } }
        public AudioClip MainLoop { get { return mainLoop; } }

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
    }
}