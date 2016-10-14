using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelLoad : MonoBehaviour {

    //as this class is a singleton it will have a single instance
    public static LevelLoad instance = null;

    //the image that acts as the loading screen
    [SerializeField]
    private Image loadingScreen;

    //text on top of the loading screen
    [SerializeField]
    private Text loadingText;

    //the music that is played in each scene
    private AudioSource backgroundMusic;

    //the different songs that are swapped in and out each scene
    [SerializeField]
    private AudioClip[] songs;

    void Awake()
    {
        //if the there is no LevelLoad object in the scene then this becomes the object/instance,
        //and if this object is not the instance then destroy it
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //don't destroy this object as it moves through the scenes
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
        //whenever the current scene is changed then call the method ChangeSongs
        SceneManager.activeSceneChanged += ChangeSongs;
    }

    //wraps the Coroutine Load in the public method LoadMethod so that it can be called from other scripts and buttons
    public void LoadMethod(int level)
    {
        StartCoroutine("Load", level);
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= ChangeSongs;
    }

    //create a coroutine that handles the loading screen, music and loading new scenes asynchronously
    IEnumerator Load(int level)
    {
        yield return StartCoroutine("FadeInLoadingScreen");

        yield return StartCoroutine("FadeOutMusic");

        yield return SceneManager.LoadSceneAsync(level);

        yield return StartCoroutine("FadeOutLoadingScreen");

        yield return StartCoroutine("FadeInMusic");
    }

    
    IEnumerator FadeOutMusic()
    {
        float t = 0.0f;
        float fadeTime = 1.0f;

        //while t is less than 1 slowly turn the volume down 
        while (t < fadeTime)
        {
            backgroundMusic.volume = Mathf.Lerp(1.0f, 0.0f, t / fadeTime);

            //increment t so that the while loop doesn't run forever and so that the lerp fade out correctly
            t += Time.smoothDeltaTime;
            yield return null;
        }

        //if the volume is slightly above mute, then make it 0 just to be sure
        if (backgroundMusic.volume < 0.15f)
            backgroundMusic.volume = 0.0f;

    }

    //same as above except the other way around
    IEnumerator FadeInMusic()
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

        //while t < 1 lerp the alpha values of the loading screen and the loading text so that they smoothly fade in
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

    //generally the same as the above, all four fade in/out methods use the same while loop approach 
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

        //disable the gameobject to ensure it doesn't interfere with the game
        loadingScreen.gameObject.SetActive(false);
    }

    //changes the clip in the audiosource based on the index of the next scene
    void ChangeSongs(Scene prev, Scene next)
    {
        //loops through all the songs...
        for(int i = 0; i < songs.Length; i++)
        {
            //...checks if the scenes index matches up with the songs position in the array...
            if(next.buildIndex == i)
            {
                //...and then changes the clip to the song in the relevant position (in the array)
                backgroundMusic.clip = songs[i];

                //if the audiosource is not already playing and the clip is loaded, then play it
                if (!backgroundMusic.isPlaying && backgroundMusic.clip.loadState == AudioDataLoadState.Loaded)
                    backgroundMusic.Play();

                break;
            }
        }
    }

}