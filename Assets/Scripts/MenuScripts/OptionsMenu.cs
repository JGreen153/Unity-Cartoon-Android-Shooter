using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    [SerializeField]
    private AudioMixer musicMixer, sfxMixer;

    [SerializeField]
    private Toggle musicToggle, sfxToggle;

    private float startMusicVolume;
    private float startSfxVolume;

    // Use this for initialization
    void Start() 
	{
        bool v = true;
        bool s = true;

        v = musicMixer.GetFloat("Volume", out startMusicVolume);
        s = sfxMixer.GetFloat("Volume", out startSfxVolume);
    }

    public void ToggleMusicVolume()
    {
        if (!musicToggle.isOn)
        {
            musicMixer.SetFloat("Volume", -80.0f);
        }
        else
        {
            musicMixer.SetFloat("Volume", startMusicVolume);
        }
    }

    public void ToggleSFXVolume()
    {
        if (!sfxToggle.isOn)
        {
            sfxMixer.SetFloat("Volume", -80.0f);
        }
        else
        {
            sfxMixer.SetFloat("Volume", startSfxVolume);
        }
    }
}