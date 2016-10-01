using UnityEngine;
using System.Collections;

public class ScorePowerup : MonoBehaviour, IPowerup {

    public delegate void UpdateScore();
    public static event UpdateScore OnUpdateScore;

    void Update()
    {
        if (transform.position.y < -4.8f)
        {
            DestroyPowerup();
        }
    }

    public void ApplyPowerup()
    {
        PlayerScore.score += 50;

        if (OnUpdateScore != null)
            OnUpdateScore();
    }

    public void DestroyPowerup()
    {
        gameObject.SetActive(false);
        transform.position = Vector2.zero;
    }

}