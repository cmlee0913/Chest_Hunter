using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_RockTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject parentObject;
    public GameObject rock;
    public GIM_Scaffolding scaffolding;
    public GIM_ScaffoldingTrigger gIM_ScaffoldingTrigger;
    public Animation trapAnimator;
    public bool isOk;
    void Update() {
        SetRock();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && gameManager.rockCount > 0) {
            isOk = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            isOk = false;
        }
    }

    void SetRock() {
        if (isOk && Input.GetButtonDown("Interactive")) {
            GameObject insRock = Instantiate(rock, this.gameObject.transform.position, this.gameObject.transform.rotation, parentObject.transform) as GameObject;
            scaffolding.input += gIM_ScaffoldingTrigger.num;
            gameManager.rockCount--;
            gameManager.RockCountUpdate();
            trapAnimator.enabled = false;
            this.enabled = false;
            insRock.GetComponent<ObjData>().enabled = false;
        }
    }
}
