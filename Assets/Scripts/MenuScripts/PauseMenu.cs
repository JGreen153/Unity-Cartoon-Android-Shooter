using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    private RectTransform pauseMenuRect;

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenuRect.localScale = Vector3.one;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuRect.localScale = Vector3.zero;
    }

}