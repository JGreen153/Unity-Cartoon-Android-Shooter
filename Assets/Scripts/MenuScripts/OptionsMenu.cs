using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public delegate void UpdateTrophyText();
    public static event UpdateTrophyText OnUpdateTrophyText;

    private static bool musicToggleStatus = true;
    private static bool sfxToggleStatus = true;  

    [SerializeField]
    private AudioMixer musicMixer, sfxMixer;

    [SerializeField]
    private Toggle musicToggle, sfxToggle;

    void Start()
    {
        musicToggle.isOn = musicToggleStatus;
        sfxToggle.isOn = sfxToggleStatus;
    }

    public void ToggleMusicVolume()
    {
        if (!musicToggle.isOn)
        {
            musicMixer.SetFloat("Volume", -80.0f);
        }
        else
        {
            musicMixer.SetFloat("Volume", 0.0f);
        }

        musicToggleStatus = musicToggle.isOn;

    }

    public void ToggleSFXVolume()
    {
        if (!sfxToggle.isOn)
        {
            sfxMixer.SetFloat("Volume", -80.0f);
        }
        else
        {
            sfxMixer.SetFloat("Volume", 0.0f);
        }

        sfxToggleStatus = sfxToggle.isOn;

    }

    public void Clear()
    {
        PlayerPrefs.SetInt("trophyCount", 0);

        TrophyCount.trophyCount = PlayerPrefs.GetInt("trophyCount");

        PlayerPrefs.Save();

        if (OnUpdateTrophyText != null)
            OnUpdateTrophyText();
    }

}