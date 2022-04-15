using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_ChestTrigger2 : MonoBehaviour
{
    public bool isPlayer = false;
    public ObjData objData;
    public GameManager gameManager;
    public GameObject sceneMover;
    public GameObject player;
    public GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        QuestUpdate();
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            isPlayer = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.name == "Player") {
            isPlayer = false;
        }
    }

    void QuestUpdate() {
        if (isPlayer) {
            if (gameManager.silverKeyCount == 0) {
                objData.id = 6000;
            }
            else if (gameManager.silverKeyCount == 1) {
                objData.id = 6100;
            }
            else if (gameManager.silverKeyCount == 2) {
                objData.id = 6200;
            }
            else if (gameManager.silverKeyCount == 3) {
                objData.id = 6300;
            }
        }
    }
}
