using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour {

    public static LevelLoad instance = null;

    [SerializeField]
    private Image loadingScreen;
    [SerializeField]
    private Text loadingText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
	void Start() 
	{
        loadingScreen.gameObject.SetActive(false);
	}

    public void LoadMethod(int level)
    {
        StartCoroutine("Load", level);
    }

    IEnumerator Load(int level)
    {
        yield return StartCoroutine("FadeInLoadingScreen");

        //yield return StartCoroutine("FadeOut");

        yield return SceneManager.LoadSceneAsync(level);

        yield return StartCoroutine("FadeOutLoadingScreen");

        //yield return StartCoroutine("FadeIn");
    }

    /*
    IEnumerator FadeOut()
    {
        float t = 0.0f;
        float fadeTime = 1.0f;

        while (t < fadeTime)
        {
            backgroundMusic.volume = Mathf.Lerp(1.0f, 0.0f, t / fadeTime);

            t += Time.smoothDeltaTime;
            yield return null;
        }

        if (backgroundMusic.volume < 0.15f)
            backgroundMusic.volume = 0.0f;

    }

    IEnumerator FadeIn()
    {
        float t = 0.0f;
        float fadeTime = 1.0f;

        while (t < fadeTime)
        {
            backgroundMusic.volume = Mathf.Lerp(0.0f, 1.0f, t / fadeTime);

            t += Time.smoothDeltaTime;
            yield return null;
        }

        if (backgroundMusic.volume > 0.95f)
            backgroundMusic.volume = 1.0f;
    }
    */

    IEnumerator FadeInLoadingScreen()
    {
        float t = 0.0f;
        float fadeTime = 1.0f;
        Color colour = loadingScreen.color;
        Color textColour = loadingText.color;
        loadingScreen.gameObject.SetActive(true);

        while (t < fadeTime)
        {
            colour.a = Mathf.Lerp(0.0f, 1.0f, t / fadeTime);
            textColour.a = Mathf.Lerp(0.0f, 1.0f, t / fadeTime);

            loadingScreen.color = colour;
            loadingText.color = textColour;

            t += Time.smoothDeltaTime;
            yield return null;
        }

    }

    IEnumerator FadeOutLoadingScreen()
    {
        float t = 0.0f;
        float fadeTime = 1.0f;
        Color colour = loadingScreen.color;
        Color textColour = loadingText.color;

        while (t < fadeTime)
        {
            colour.a = Mathf.Lerp(1.0f, 0.0f, t / fadeTime);
            textColour.a = Mathf.Lerp(1.0f, 0.0f, t / fadeTime);

            loadingScreen.color = colour;
            loadingText.color = textColour;

            t += Time.smoothDeltaTime;
            yield return null;
        }

        loadingScreen.gameObject.SetActive(false);
    }
}