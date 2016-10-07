using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour {

    public delegate void GameFinished();
    public static event GameFinished OnGameFinished;

    [SerializeField]
    private int scoreToWin;

    public static int ScoreToWin;

    private AudioSource winMusic;

    [SerializeField]
    private float platinumTime, goldTime, silverTime;

    [SerializeField]
    private Animator gameOverAnimator, youWinAnimator, perfectWinAnimator;

    [SerializeField]
    private Image gameWinMedal, perfectWinMedal;

    [SerializeField]
    private AudioClip[] winMusicSongs; 

    [SerializeField]
    private Sprite[] medals;

    private GameObject player;

    private bool hasBeenHit;

    private bool gameIsRunning;

    // Use this for initialization
	void Start() 
	{
        hasBeenHit = false;

        gameIsRunning = true;

        winMusic = GetComponent<AudioSource>();

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null)
            player = p;
	}

    void Update()
    {
        ScoreToWin = scoreToWin;
    }

    void OnEnable()
    {
        PlayerHealth.OnHealthUpdated += PlayerHasBeenHit;
        PlayerHealth.OnTimeStopped += AnimateGameOverScreen;
        EnemyHealth.OnUpdateScore += CheckConditions;
        ScorePowerup.OnUpdateScore += CheckConditions;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthUpdated -= PlayerHasBeenHit;
        PlayerHealth.OnTimeStopped -= AnimateGameOverScreen;
        EnemyHealth.OnUpdateScore -= CheckConditions;
        ScorePowerup.OnUpdateScore -= CheckConditions;
    }

    void PlayerHasBeenHit()
    {
        hasBeenHit = true;
    }

    void AnimateGameOverScreen()
    {
        winMusic.clip = winMusicSongs[0];
        winMusic.Play();

        gameOverAnimator.Play("GameOverFadeIn");

        Time.timeScale = 0.5f;

        gameIsRunning = false;
    }

    void CheckConditions()
    {
        if(PlayerScore.score >= scoreToWin && hasBeenHit && gameIsRunning)
        {
            if (OnGameFinished != null)
                OnGameFinished();

            winMusic.clip = winMusicSongs[1];
            winMusic.Play();

            youWinAnimator.Play("GameWinFadeIn");

            player.GetComponent<Collider2D>().isTrigger = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<PlayerScore>().enabled = false;

            Time.timeScale = 0.5f;

            if (TimeSurvived.time <= goldTime)
            {
                gameWinMedal.sprite = medals[2];
            }
            else if(TimeSurvived.time > goldTime && TimeSurvived.time <= silverTime)
            {
                gameWinMedal.sprite = medals[1];
            }
            else if(TimeSurvived.time > silverTime)
            {
                gameWinMedal.sprite = medals[0];
            }

            gameIsRunning = false;

        }
        else if (PlayerScore.score >= scoreToWin && !hasBeenHit && gameIsRunning)
        {
            if (OnGameFinished != null)
                OnGameFinished();

            winMusic.clip = winMusicSongs[2];
            winMusic.Play();

            perfectWinAnimator.Play("PerfectFadeIn");

            player.GetComponent<Collider2D>().isTrigger = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<PlayerScore>().enabled = false;

            Time.timeScale = 0.5f;

            if (TimeSurvived.time <= platinumTime)
            {
                perfectWinMedal.sprite = medals[3];

                TrophyCount.trophyCount++;

                PlayerPrefs.SetInt("trophyCount", TrophyCount.trophyCount);
                PlayerPrefs.Save();
            }
            else if (TimeSurvived.time > platinumTime && TimeSurvived.time <= goldTime)
            {
                perfectWinMedal.sprite = medals[2];
            }
            else if (TimeSurvived.time > goldTime && TimeSurvived.time <= silverTime)
            {
                perfectWinMedal.sprite = medals[1];
            }
            else if(TimeSurvived.time > silverTime)
            {
                perfectWinMedal.sprite = medals[0];
            }

            gameIsRunning = false;

        }
    }

    public void ResetTime()
    {
        Time.timeScale = 1;
    }

}