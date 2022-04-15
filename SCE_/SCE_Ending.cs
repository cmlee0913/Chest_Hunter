using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SCE_Ending : MonoBehaviour
{
    GameObject FadeEffect;
    Player playerScript;
    SCE_SceneChangeEffect FadeEffectCP;

    public GameObject ButtonGroup;
    public GameObject menuPanel;
    void Awake()
    {
        FadeEffect = GameObject.Find("Fade");
        FadeEffectCP = FadeEffect.GetComponent<SCE_SceneChangeEffect>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (FadeEffectCP.checkFadeIn == false) {
            Time.timeScale = 0;
            FadeEffectCP.StartFadeIn();
            Time.timeScale = 1;
        }
        Invoke("FadeOut", 10f);
    }

    public void Setting()
    {
        Time.timeScale = 0;
        Debug.Log("Setting");
        menuPanel.SetActive(true);
        ButtonGroup.GetComponent<Button>().enabled = false;
    }

    public void SettingExit()
    {
        Time.timeScale = 1;
        Debug.Log("SettingExit");
        menuPanel.SetActive(false);
        ButtonGroup.GetComponent<Button>().enabled = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void FadeOut() {
        FadeEffectCP.gameObject.SetActive(true);
        FadeEffectCP.StartFadeOut();
        if (FadeEffectCP.checkFadeOut) {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
