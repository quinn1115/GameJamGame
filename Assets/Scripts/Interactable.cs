using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float soundCooldown = 0.5f;
    public float soundCooldownMax = 0.5f;

    AudioSource audioSource;
    AudioClip clip;

    public void Setup(AudioClip c)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        clip = c;
    }

    private void Update()
    {
        soundCooldown -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (soundCooldown <= 0)
        {
            audioSource.PlayOneShot(clip);
            soundCooldown = soundCooldownMax;
        }
            
    }
}
