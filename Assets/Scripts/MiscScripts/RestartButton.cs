using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    private LevelLoad levelLoader;
    private Button button;

    // Use this for initialization
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoad>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => levelLoader.LoadMethod(SceneManager.GetActiveScene().buildIndex));
    }
}