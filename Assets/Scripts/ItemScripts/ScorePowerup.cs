using UnityEngine;
using System.Collections;

public class ScorePowerup : MonoBehaviour, IPowerup {

    public delegate void UpdateScore();
    public static event UpdateScore OnUpdateScore;

    [SerializeField]
    private int scoreIncrease;

    private AudioSource powerUpSound;

    void Start()
    {
        powerUpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y < -4.8f)
        {
            DestroyPowerup();
        }
    }

    public void ApplyPowerup()
    {
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