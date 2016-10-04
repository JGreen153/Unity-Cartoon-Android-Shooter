using UnityEngine;
using System.Collections;

public class ScorePowerup : MonoBehaviour, IPowerup {

    public delegate void UpdateScore();
    public static event UpdateScore OnUpdateScore;

    [SerializeField]
    private int scoreIncrease;

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

        if (OnUpdateScore != null)
            OnUpdateScore();
    }

    public void DestroyPowerup()
    {
        gameObject.SetActive(false);
        transform.position = Vector2.zero;
    }

}