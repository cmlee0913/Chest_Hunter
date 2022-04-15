using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_BombPos : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject bomb;
    public GameObject questLight;
    public GameObject parentObject;
    public ObjData objData;
    public bool insBomb;
    void Start()
    {
        
    }

    void Update()
    {
        if (gameManager.hasBomb) {
            ActiveLight();
        }

        if (insBomb) {
            if (Input.GetButtonDown("Interactive") && questLight) {
                Destroy(questLight);
            }
        }

        if (insBomb && gameManager.bombReady) {
            InsBomb();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (gameManager.hasBomb) {
            objData.id = 4030;
            insBomb = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (gameManager.hasBomb) {
            insBomb = false;
        }
    }

    void InsBomb() {
        Instantiate(bomb, this.transform.position, this.transform.rotation, parentObject.transform);
        insBomb = false;
        gameManager.hasBomb = false;
        Destroy(this.gameObject);
    }

    public void ActiveLight() {
        if (questLight)
            questLight.SetActive(true);
    }
}
