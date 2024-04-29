using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumenMaster;
    public Slider volumenFX;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;

    private void Awake()
    {
        volumenMaster.onValueChanged.AddListener(ChangeVolumeMaster);
        volumenFX.onValueChanged.AddListener(ChangeVolumeFX);
    }

    public void SetMute()
    {

        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        }
        else
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }
    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }
    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("FxAudio", v);
    }
    public void PlaySoundButton()
    {
        fxSource.clip = clickSound;
        fxSource.Play();
    }
}
