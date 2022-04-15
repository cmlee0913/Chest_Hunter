using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SUD_Controller : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public void BGMSetting() {
        float volume = BGMSlider.value;

        if (volume == 40f) {
            masterMixer.SetFloat("BGM", -80f);
        }
        else {
            masterMixer.SetFloat("BGM", volume);
        }
    }

    public void SFXSetting() {
        float volume = SFXSlider.value;

        if (volume == 40f) {
            masterMixer.SetFloat("SFX", -80f);
        }
        else {
            masterMixer.SetFloat("SFX", volume);
        }
    }
}
