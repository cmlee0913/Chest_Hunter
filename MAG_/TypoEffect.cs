using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypoEffect : MonoBehaviour
{
    string targetMsg;
    public int CharPerSeconds;
    public GameObject endCursor;
    Text msgText;
    int index;
    float interval;

    void Awake() {
        msgText = GetComponent<Text>();
    }

    public void SetMsg(string msg) {
        targetMsg = msg;
        EffectStart();
    }

    void EffectStart() {
        msgText.text = "";
        index = 0;
        endCursor.SetActive(false);

        interval = 1.0f / CharPerSeconds;
        Invoke("Effecting", interval);
    }

    void Effecting() {
        if (msgText.text == targetMsg) {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", 1 / CharPerSeconds);
    }

    void EffectEnd() {
        endCursor.SetActive(true);
    }
}
