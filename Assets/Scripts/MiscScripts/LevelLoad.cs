using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelLoad : MonoBehaviour {

    public static LevelLoad instance = null;

    [SerializeField]
    private Image loadingScreen;
    [SerializeField]
    private Text loadingText;

    private AudioSource backgroundMusic;

    [SerializeField]
    private AudioClip[] songs;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        backgroundMusic = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start() 
	{
        loadingScreen.gameObject.SetActive(false);
	}

    void OnEnable()
    {
        SceneManager.activeSceneChanged += ChangeSongs;
    }

    public void LoadMethod(int level)
    {
        StartCoroutine("Load", level);
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= ChangeSongs;
    }

    IEnumerator Load(int level)
    {
        yield return StartCoroutine("FadeInLoadingScreen");

        yield return StartCoroutine("FadeOut");

        yield return SceneManager.LoadSceneAsync(level);

        yield return StartCoroutine("FadeOutLoadingScreen");

        yield return StartCoroutine("FadeIn");
    }

    
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

    void ChangeSongs(Scene prev, Scene next)
    {
        for(int i = 0; i < songs.Length; i++)
        {
            if(next.buildIndex == i)
            {
                backgroundMusic.clip = songs[i];

                if (!backgroundMusic.isPlaying && backgroundMusic.clip.loadState == AudioDataLoadState.Loaded)
                    backgroundMusic.Play();

                break;
            }
        }
    }

}