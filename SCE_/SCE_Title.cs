using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCE_Title : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject ButtonGroup;
    public GameObject menuPanel;
    GameObject FadeEffect;
    SCE_SceneChangeEffect FadeEffectCP;

    void Awake() {
        Cursor.visible = true;
        audioSource = GetComponent<AudioSource>();
        FadeEffect = GameObject.Find("Fade");
        FadeEffectCP = FadeEffect.GetComponent<SCE_SceneChangeEffect>();
    }

    void Update() {
        if (FadeEffectCP.checkFadeIn == false) {
            FadeEffectCP.StartFadeIn();
        }
        else if (FadeEffectCP.checkFadeOut == false &&
                FadeEffectCP.checkFadeIn == true &&
                FadeEffect.activeSelf == true) {
            FadeEffectCP.StartFadeOut();
            if (FadeEffectCP.checkFadeOut) {
                SceneManager.LoadScene("Tutorial");
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("StartGame");
        audioSource.Play();
        FadeEffect.SetActive(true);
    }

    public void Setting()
    {
        Debug.Log("Setting");
        audioSource.Play();
        menuPanel.SetActive(true);
        foreach (Button BTN in ButtonGroup.GetComponentsInChildren<Button>()) {
            BTN.enabled = false;
        }
    }

    public void SettingExit()
    {
        Time.timeScale = 1;
        Debug.Log("SettingExit");
        audioSource.Play();
        menuPanel.SetActive(false);
        foreach (Button BTN in ButtonGroup.GetComponentsInChildren<Button>()) {
            BTN.enabled = true;
        }
    }

    public void Exit()
    {
        Time.timeScale = 1;
    #if UNITY_EDITOR // 유니티 에디터 안에서
        UnityEditor.EditorApplication.isPlaying = false;
    #else // 빌드된 어플리케이션 안에서
        Application.Quit();
    #endif
    }

}
