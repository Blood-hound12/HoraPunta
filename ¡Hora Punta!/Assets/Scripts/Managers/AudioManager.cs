using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumenMaster;
    public Toggle mute;
    public AudioMixer mixer;
    private float lastVolume;

    private void Awake()
    {
        volumenMaster.onValueChanged.AddListener(ChangeVolumeMaster);
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
    //public void PlaySoundButton()
    //{
    // fxSource.PlayOnShot(clickSound);
    //}
}
