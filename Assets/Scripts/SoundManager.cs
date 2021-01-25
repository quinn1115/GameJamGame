using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        // lazy to put script on every sinlge object
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");
        for (int i = 0; i < interactables.Length; i++)
        {
            interactables[i].AddComponent<AudioSource>();
            Interactable inter = interactables[i].AddComponent<Interactable>();
            inter.Setup(clips[Random.Range(0, clips.Length)]);
        }
    }
}
