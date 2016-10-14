using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    //the pause menu
    [SerializeField]
    private RectTransform pauseMenuRect;

    public void Pause()
    {
        //when paused stop time...
        Time.timeScale = 0;
        //...and scale the pause menu so it covers the screen 
        pauseMenuRect.localScale = Vector3.one;
    }

    public void Resume()
    {
        //when the player resumes un-pause time...
        Time.timeScale = 1;
        //...and scale the pause menu to nothing
        pauseMenuRect.localScale = Vector3.zero;
    }

}