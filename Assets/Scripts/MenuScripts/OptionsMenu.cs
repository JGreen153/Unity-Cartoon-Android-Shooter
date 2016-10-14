using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    //a delegate/event in order to update the trophy ui
    public delegate void UpdateTrophyText();
    public static event UpdateTrophyText OnUpdateTrophyText;

    //a static bool which holds the current state of the music and sfx toggles
    private static bool musicToggleStatus = true;
    private static bool sfxToggleStatus = true;  

    //audioMixers for the music and sfx to control their volume
    [SerializeField]
    private AudioMixer musicMixer, sfxMixer;

    //toggles which allow the player to toggle the music on and off
    [SerializeField]
    private Toggle musicToggle, sfxToggle;

    void Start()
    {
        //music and sfx toggles are set to the aforementioned static bools to ensure the users choice is remembered
        musicToggle.isOn = musicToggleStatus;
        sfxToggle.isOn = sfxToggleStatus;
    }

    //method called when the user presses the toggle
    public void ToggleMusicVolume()
    {
        //if the toggle isn't on...
        if (!musicToggle.isOn)
        {
            //...set the volume to "mute"...
            musicMixer.SetFloat("Volume", -80.0f);
        }
        else
        {
            //...otherwise, set the volume to the default value
            musicMixer.SetFloat("Volume", 0.0f);
        }

        //set the static bool to the current state of the toggle so the game remembers it
        musicToggleStatus = musicToggle.isOn;

    }

    //same as ToggleMusicVolume but for the sfx
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

    //resets the players progress in the game
    public void Clear()
    {
        //set the playerPref (which represents the players medal amount) to 0 
        PlayerPrefs.SetInt("trophyCount", 0);

        //set the trophy count to the playerPref (to update the ui)
        TrophyCount.trophyCount = PlayerPrefs.GetInt("trophyCount");

        PlayerPrefs.Save();

        //call delegate/event to update the ui
        if (OnUpdateTrophyText != null)
            OnUpdateTrophyText();
    }

}