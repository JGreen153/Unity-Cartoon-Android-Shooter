using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour {

    //delegate/event to notify scripts on when the game has stopped
    public delegate void GameFinished();
    public static event GameFinished OnGameFinished;

    //the score that is required to beat a stage
    [SerializeField]
    private int scoreToWin;

    //a static int to easily get scoreToWin from other scripts
    public static int ScoreToWin;

    //the audiosource that plays the music when the player wins/dies
    private AudioSource winMusic;

    //the animators that play when the player dies, wins and has a perfect win, respectively
    [SerializeField]
    private Animator gameOverAnimator, youWinAnimator, perfectWinAnimator;

    //the medals that is shown when the player wins or has a perfect win
    [SerializeField]
    private Image gameWinMedal, perfectWinMedal;

    //the songs that play during the aforementioned different win/lose conditions
    [SerializeField]
    private AudioClip[] winMusicSongs; 

    //array of all the medals that could possibly be shown
    [SerializeField]
    private Sprite[] medals;

    private GameObject player;

    //determines whether or not the player has been hit
    private bool hasBeenHit;

    //determines whether or not the game is running
    private bool gameIsRunning;

    // Use this for initialization
	void Start() 
	{
        //set the bool to false because the player hasn't been hit yet...
        hasBeenHit = false;
        //...and make sure this is set to true
        gameIsRunning = true;

        winMusic = GetComponent<AudioSource>();

        //create a local variable to get the player
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        //check if p isn't null (check that the layer exists) and then assign player to p
        if (p != null)
            player = p;

        //make sure that the static var is equal to the standard global class variable
        ScoreToWin = scoreToWin;
    }

    void OnEnable()
    {
        //bunch of events/delegates centred around checking if the game has ended or if the player has been hit
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
        //set the music to the game over song and play it
        winMusic.clip = winMusicSongs[0];
        winMusic.Play();

        //play the game over animation
        gameOverAnimator.Play("GameOverFadeIn");

        //activate slow-mo so everything looks cool
        Time.timeScale = 0.5f;

        //the game is no longer running
        gameIsRunning = false;
    }

    void CheckConditions()
    {
        //if the player has hit the winning score, been hit, and the game is still running...
        if(PlayerScore.score >= scoreToWin && hasBeenHit && gameIsRunning)
        {
            //...call the delegate to stop the timer counting...
            if (OnGameFinished != null)
                OnGameFinished();

            //...change the song to the standard win song and play it...
            winMusic.clip = winMusicSongs[1];
            winMusic.Play();

            //...play the standard win animation...
            youWinAnimator.Play("GameWinFadeIn");

            //...disable a bunch of scripts on the player and make the collider a trigger to prevent collisions...
            player.GetComponent<Collider2D>().isTrigger = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<PlayerScore>().enabled = false;

            //...activate the slow-mo...
            Time.timeScale = 0.5f;

            //...if the player beat the game faster than 50 seconds display the gold medal, if less than 65 seconds display the silver medal
            //and if slower than that display the bronze medal...
            if (TimeSurvived.time <= 50)
            {
                gameWinMedal.sprite = medals[2];
            }
            else if(TimeSurvived.time > 50 && TimeSurvived.time <= 65)
            {
                gameWinMedal.sprite = medals[1];
            }
            else if(TimeSurvived.time > 65)
            {
                gameWinMedal.sprite = medals[0];
            }

            //...then change the bool because the game isn't playing
            gameIsRunning = false;

        }
        //generally the same as the above chunk of code except it checks if they haven't been hit...
        else if (PlayerScore.score >= scoreToWin && !hasBeenHit && gameIsRunning)
        {
            if (OnGameFinished != null)
                OnGameFinished();

            //...plays a different song...
            winMusic.clip = winMusicSongs[2];
            winMusic.Play();

            //...a different animation...
            perfectWinAnimator.Play("PerfectFadeIn");

            player.GetComponent<Collider2D>().isTrigger = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<PlayerScore>().enabled = false;

            Time.timeScale = 0.5f;

            //...and an extra if statement check to see if they're under 35 seconds, if they are
            //increment their trophyCount, set their playerpref to the current trophyCount and save the playerPrefs automatically
            if (TimeSurvived.time <= 35)
            {
                perfectWinMedal.sprite = medals[3];

                TrophyCount.trophyCount++;

                PlayerPrefs.SetInt("trophyCount", TrophyCount.trophyCount);
                PlayerPrefs.Save();
            }
            else if (TimeSurvived.time > 35 && TimeSurvived.time <= 50)
            {
                perfectWinMedal.sprite = medals[2];
            }
            else if (TimeSurvived.time > 50 && TimeSurvived.time <= 65)
            {
                perfectWinMedal.sprite = medals[1];
            }
            else if(TimeSurvived.time > 65)
            {
                perfectWinMedal.sprite = medals[0];
            }

            gameIsRunning = false;

        }
    }

    public void ResetTime()
    {
        //method to reset time after the slow-mo's been activated and a button's been pressed
        Time.timeScale = 1;
    }

}