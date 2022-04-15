using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public Animator talkPanel;
    public Animator playerPanel;
    public TypoEffect talk;
    public Text keyText;
    public Text RockText;
    public GameObject player;
    public GameObject scanObject;
    public GameObject sceneMover;
    public GameObject gameOver;
    public GameObject bomb;
    public GameObject parentObject;
    public bool UIMode = false;
    public bool isStart;
    public bool isChecking;
    public int talkIndex;
    public int silverKeyCount;
    public int rockCount;
    public bool hasBomb;
    public bool bombReady;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (player != null && player.GetComponent<Player>().isDie) {
            UIMode = true;
            gameOver.SetActive(true);
        }
        else if (!GameObject.Find("Player")) {
            UIMode = true;
            gameOver.SetActive(true);
        }
        CursorActive();
    }

    public void Checking(GameObject scanObj) {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isGimmik);
        Debug.Log("Checking");
        talkPanel.SetBool("isShow", isChecking);
        playerPanel.SetBool("isON", isChecking);
    }

    public void Talk(int id, bool isGimmik) {
        string talkData = talkManager.GetTalk(id, talkIndex);
        UIMode = true;

        if (talkData == null) {
            isChecking = false;
            audioSource.Stop();
            QuestUpdate(id);
            talkIndex = 0;
            UIMode = false;
            return;
        }
        audioSource.Play();
        talk.SetMsg(talkData);

        isChecking = true;
        talkIndex++;
    }

    public void QuestUpdate(int id) {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null) {
            if (id == 100 || id == 160 || id == 110) {
                Destroy(GameObject.Find("StartPoint"));
            }
            else if (120 <= id && id < 150) {
                Destroy(GameObject.FindWithTag("TalkBox"));
            }
            else if (id == 150) {
                Instantiate(sceneMover, player.transform.position, player.transform.rotation, parentObject.transform);
            }
            else if (id == 200) {
                Destroy(GameObject.FindWithTag("TalkBox"));
            }
            else if (id == 300) {
                Destroy(GameObject.FindWithTag("TalkBox"));
            }
            else if (id == 4020) {
               hasBomb = true;
               Destroy(GameObject.Find("GIM_Chest"));
            }
            else if (id == 4030) {
               bombReady = true; 
            }
            else if (id == 3100) {
                Instantiate(bomb, player.transform.position - new Vector3(0, 1, 0), player.transform.rotation, parentObject.transform);
            }
            else if (id == 3300) {
                Destroy(GameObject.FindWithTag("TalkBox"));
            }
            else if (id == 2200) {
                Destroy(scanObject);
                rockCount++;
                RockCountUpdate();
            }
            else if (id == 6300) {
                Instantiate(sceneMover, player.transform.position, player.transform.rotation, parentObject.transform);
            }
        }
    }

    public void KeyCountUpdate() {
        keyText.text = "X " + silverKeyCount;
    }

    public void RockCountUpdate() {
        if (RockText)
            RockText.text = "X " + rockCount;
    }

    void CursorActive() {
        if (Input.GetKeyDown(KeyCode.LeftAlt) || UIMode) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
