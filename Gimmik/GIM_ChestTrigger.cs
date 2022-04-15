using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_ChestTrigger : MonoBehaviour
{
    public bool isPlayer = false;
    public ObjData objData;
    public GameManager gameManager;
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
                objData.id = 4000;
            }
            else if (gameManager.silverKeyCount == 1) {
                objData.id = 4010;
            }
            else if (gameManager.silverKeyCount == 2) {
                objData.id = 4020;
            }
        }
    }
}
