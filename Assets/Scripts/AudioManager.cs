using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource audioSource;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private AudioClip titleLoop;
    [SerializeField] private AudioClip mainLoop;

    public AudioClip TitleLoop { get { return titleLoop; } }
    public AudioClip MainLoop { get { return mainLoop; } }

    private void Awake()
    {
        CreateInstance();
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

    private void CreateInstance()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ChangeToMainLoop()
    {
        audioSource.clip = mainLoop;
        audioSource.Play();
    }
}
