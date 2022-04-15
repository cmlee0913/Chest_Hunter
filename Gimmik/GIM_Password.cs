using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_Password : MonoBehaviour
{
    AudioSource audioSource;
    public string answer;
    public string input;
    public GameObject Key_Silver;
    public GameObject parent;
    public Player player;
    public GameObject trigger;
    public bool isCheck;
    public GameObject ButtonUI;
    public GameObject Light;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (input.Length == answer.Length)
            Check();
    }

    void Check() {
        if (answer == input) {
            isCheck = true;
            Invoke("GiveKey", 1.2f);
            ButtonUI.SetActive(false);
            Light.SetActive(false);
            trigger.SetActive(false);
            player.scanObject = null;
            this.enabled = false;
        }
        else {
            input = "";
            ButtonUI.SetActive(false);
        }
    }

    public void GiveKey() {
        if (!audioSource.isPlaying)
            audioSource.Play();
        Instantiate(Key_Silver, parent.transform.position, parent.transform.rotation, parent.transform);
    }
}
