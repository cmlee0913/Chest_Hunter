using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_Rock : MonoBehaviour
{
    AudioSource audioSource;
    public GameManager gameManager;
    public GameObject oldRock;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (oldRock == null && !audioSource.isPlaying) {
            audioSource.Play();
            this.enabled = false;
        }
        if (gameManager.hasBomb && gameObject.transform.GetChild(3))
            Destroy(gameObject.transform.GetChild(3).gameObject);
    }
}
