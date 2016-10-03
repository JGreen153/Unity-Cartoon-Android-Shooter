using UnityEngine;
using System.Collections;

public class FinishManager : MonoBehaviour {

    public delegate void GameFinished();
    public static event GameFinished OnGameFinished;

    [SerializeField]
    private int scoreToWin;

    [SerializeField]
    private Animator gameOverAnimator, youWinAnimator, perfectWinAnimator;

    private GameObject player;

    public static bool hasBeenHit;

    // Use this for initialization
	void Start() 
	{
        hasBeenHit = false;

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null)
            player = p;
	}

    void OnEnable()
    {
        PlayerHealth.OnHealthUpdated += PlayerHasBeenHit;
        PlayerHealth.OnTimeStopped += AnimateGameOverScreen;
        EnemyHealth.OnUpdateScore += CheckConditions;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthUpdated -= PlayerHasBeenHit;
        PlayerHealth.OnTimeStopped -= AnimateGameOverScreen;
        EnemyHealth.OnUpdateScore -= CheckConditions;
    }

    void PlayerHasBeenHit()
    {
        hasBeenHit = true;
    }

    void AnimateGameOverScreen()
    {
        gameOverAnimator.Play("GameOverFadeIn");

        Time.timeScale = 0.5f;
    }

    void CheckConditions()
    {
        if(PlayerScore.score == scoreToWin && hasBeenHit)
        {
            youWinAnimator.Play("GameWinFadeIn");

            player.GetComponent<Collider2D>().isTrigger = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<PlayerScore>().enabled = false;

            Time.timeScale = 0.5f;

            if (OnGameFinished != null)
                OnGameFinished();
        }
        else if (PlayerScore.score == scoreToWin && !hasBeenHit)
        {
            perfectWinAnimator.Play("PerfectFadeIn");

            player.GetComponent<Collider2D>().isTrigger = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerShoot>().enabled = false;
            player.GetComponent<PlayerScore>().enabled = false;

            TrophyCount.trophyCount++;

            Time.timeScale = 0.5f;

            if (OnGameFinished != null)
                OnGameFinished();
        }
    }

    public void ResetTime()
    {
        Time.timeScale = 1;
    }

}