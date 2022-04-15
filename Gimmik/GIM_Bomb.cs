using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM_Bomb : MonoBehaviour
{
    public GameManager gameManager;
    public bool isReady;
    public GameObject burstEffect;
    public GameObject player;
    public GameObject OldRock;
    public GameObject talkBox;
    public GameObject parent;
    public GIM_Password gIM_Password;
    GameObject tb;
    public int setId;
    void Start()
    {

    }

    void Update()
    {
        player = GameObject.Find("Player");
        parent = GameObject.Find("GameObject");
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") 
            if (GameObject.Find("Rock (3)")) {
                OldRock = GameObject.Find("Rock (3)");
            }
            else {
                OldRock = null;
            }
    }

    public void Bomb() {
        Instantiate(burstEffect, this.transform.position, this.transform.rotation);
        if (OldRock != null) {
            if (OldRock == player) {
                GameOverUI();
            }
            Destroy(OldRock);
        } 
        if (OldRock != player) {
            tb = Instantiate(talkBox, player.transform.position, player.transform.rotation, parent.transform) as GameObject;
            tb.GetComponent<ObjData>().id = setId;
            if (setId == 3300) {
                gIM_Password.GiveKey();
                gIM_Password.trigger.SetActive(false);
            }
        }
        Destroy(this.gameObject);
    }

    void GameOverUI() {
        gameManager.UIMode = true;
        gameManager.gameOver.SetActive(true);
    }
}
