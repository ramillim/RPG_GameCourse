using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] noise;
    private AudioClip noiseClip;
    private float timeCounter = 0f;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (timeCounter <= 0)
        {
            int index = Random.Range(0, noise.Length);
            noiseClip = noise[index];
            audioSource.clip = noiseClip;
            audioSource.Play();
            timeCounter = Random.Range(30f, 120f);
        }

        timeCounter -= Time.deltaTime;
    }
}
