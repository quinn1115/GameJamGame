using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float soundCooldown = 0.5f;
    public float soundCooldownMax = 0.5f;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    public void Setup(AudioClip c)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.spatialBlend = 1.0f;
        clip = c;
    }

    protected void Update()
    {
        soundCooldown -= Time.deltaTime;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (soundCooldown <= 0 && clip != null)
        {
            audioSource.PlayOneShot(clip);
            soundCooldown = soundCooldownMax;
        }
            
    }
}
