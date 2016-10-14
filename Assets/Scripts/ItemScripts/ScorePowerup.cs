using UnityEngine;
using System.Collections;

public class ScorePowerup : MonoBehaviour, IPowerup {

    //delegate/event to update the scoreUI
    public delegate void UpdateScore();
    public static event UpdateScore OnUpdateScore;

    //the amount that the score will increase
    [SerializeField]
    private int scoreIncrease;

    private AudioSource powerUpSound;

    void Start()
    {
        powerUpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if the powerup has fallen below the screen then destroy it
        if (transform.position.y < -4.8f)
        {
            DestroyPowerup();
        }
    }

    public void ApplyPowerup()
    {
        //if the score after collecting the powerup is less than the score required to win then increase the score,
        //otherwise set the score equal to the score required to win
        if (PlayerScore.score + scoreIncrease < FinishManager.ScoreToWin)
            PlayerScore.score += scoreIncrease;
        else if (PlayerScore.score + scoreIncrease >= FinishManager.ScoreToWin)
            PlayerScore.score = FinishManager.ScoreToWin;

        powerUpSound.Play();

        if (OnUpdateScore != null)
            OnUpdateScore();
    }

    public void DestroyPowerup()
    {
        //disable the powerup in 0.15f seconds (to allow the powerup sfx to play)
        Invoke("Disable", 0.15f);
    }

    void Disable()
    {
        gameObject.SetActive(false);
        transform.position = Vector2.zero;
    }

    void OnDisable()
    {
        CancelInvoke();
    }

}