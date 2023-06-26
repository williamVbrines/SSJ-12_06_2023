using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TooLoo;

namespace ssj12062023
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private AudioSource backgroundMusic;
        [SerializeField] private AudioSource ambience;
        [SerializeField] private AudioSource sfx;
        [SerializeField] private AudioSource voice;

        [Space(20)]
        [Header("Audio Clips")]

        [SerializeField] private AudioClip titleLoop;
        [SerializeField] private AudioClip mainLoop;
        [SerializeField] private AudioClip ambienceLoop;

        public AudioClip TitleLoop { get { return titleLoop; } }
        public AudioClip MainLoop { get { return mainLoop; } }

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            backgroundMusic.clip = titleLoop;
            backgroundMusic.Play();
        }

        private void Update()
        {
            transform.position = mainCamera.transform.position;
        }


        public void VolumeUp()
        {
            backgroundMusic.volume += 0.1f;
        }

        public void VolumeDown()
        {
            backgroundMusic.volume -= 0.1f;
        }

        public void ChangeToMainLoop()
        {
            backgroundMusic.Stop();
            backgroundMusic.clip = mainLoop;
            backgroundMusic.volume = 0.3f;
            backgroundMusic.Play();
        }

        public void PlayAmbience()
        {
            ambience.clip = ambienceLoop;
            ambience.Play();
        }

        public void PlaySFX(AudioClip playedSFX)
        {
            sfx.PlayOneShot(playedSFX);
        }

        public void PlayVoice(AudioClip line)
        {
            voice.PlayOneShot(line);
        }
    }
}