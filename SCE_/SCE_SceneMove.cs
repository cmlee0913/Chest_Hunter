using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCE_SceneMove : MonoBehaviour
{
    public string nextScene;
    public GameObject fade;
    public SCE_SceneChangeEffect FadeEffectCP;
    bool playerIn;
    void Update() {
        if (playerIn) {
            FadeEffectCP.StartFadeOut();
            if (FadeEffectCP.checkFadeOut) {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    void OnTriggerEnter(Collider player) {
        if (player.tag == "Player") {
            fade.SetActive(true);
            playerIn = true;
        }
    }
}
