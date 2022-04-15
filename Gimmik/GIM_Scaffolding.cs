using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_Scaffolding : MonoBehaviour
{
    AudioSource audioSource;
    public string input;
    public string answer;
    public Player player;
    public GameObject Key_Silver;
    public GameObject Light;
    public GameObject[] scaffolding;
    public GameObject trigger;
    GameObject keyRespawn;
    public bool isCheck;

    void Awake()
    {
        if (GetComponent<AudioSource>())
            audioSource = GetComponent<AudioSource>();
        scaffolding = GameObject.FindGameObjectsWithTag("scaffolding");
        keyRespawn = GameObject.Find("GIM_ScaKeySpawn");
    }
    void Update()
    {
        if (input.Length == answer.Length)
            Check();
    }

    void Check() {
        int matchNum = 0;
        foreach(char a in input) {
            if (!answer.Contains(a.ToString())) {
                break;
            }
            matchNum++;
        }

        if (matchNum == 6)
            isCheck = true;

        if (isCheck) {
            Invoke("ClearPuzzle", 0.4f);
            if (!audioSource.isPlaying)
                audioSource.Play();
            Invoke("GiveKey", 1.2f);
            trigger.SetActive(false);
            if (player.scanObject)
                player.scanObject = null;
            this.enabled = false;
        }
    }

    void GiveKey() {
        Instantiate(Key_Silver, keyRespawn.transform.position, keyRespawn.transform.rotation, gameObject.transform);
    }

    void ClearPuzzle() {
        foreach(GameObject Scaffold in scaffolding) {
            Renderer ScaffoldColor = Scaffold.GetComponent<Renderer>();
            ScaffoldColor.material.color = Color.green;
        }
    }
}
