using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstEffect : MonoBehaviour
{
    public GameObject burstEffect;
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
    }
}
