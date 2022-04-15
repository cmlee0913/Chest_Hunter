using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GIM_PasswordTrigger : MonoBehaviour
{
    public GameObject ButtonUI;
    public GameManager GetManager;
    public GIM_Password gIM_Password;

    void Start()
    {
        GetManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gIM_Password.isCheck)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            Debug.Log("player in");
            ButtonUI.SetActive(true);
            GetManager.UIMode = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.name == "Player") {
            ButtonUI.SetActive(false);
            GetManager.UIMode = false;
        }
    }
}
