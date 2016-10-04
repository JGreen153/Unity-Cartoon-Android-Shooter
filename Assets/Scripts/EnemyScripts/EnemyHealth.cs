using UnityEngine;
using System.Collections;

public class EnemyHealth : Health
{
    public delegate void UpdateScore();
    public static event UpdateScore OnUpdateScore;

    [SerializeField]
    private int enemyScore;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Die();
        }

        if (other.gameObject.GetComponent<BulletBehaviour>() != null)
        {
            Damage(other.gameObject.GetComponent<BulletBehaviour>().Damage);

            if (PlayerScore.score + enemyScore < FinishManager.ScoreToWin)
                PlayerScore.score += enemyScore;
            else if (PlayerScore.score + enemyScore >= FinishManager.ScoreToWin)
                PlayerScore.score = FinishManager.ScoreToWin;        

            if (OnUpdateScore != null)
                OnUpdateScore();
        }

        if(other.gameObject.GetComponent<RocketExplosion>() != null)
        {
            Damage(1);

            if (PlayerScore.score + enemyScore / 2 < FinishManager.ScoreToWin)
                PlayerScore.score += enemyScore / 2;
            else if (PlayerScore.score + enemyScore / 2 >= FinishManager.ScoreToWin)
                PlayerScore.score = FinishManager.ScoreToWin;

            if (OnUpdateScore != null)
                OnUpdateScore();
        }
    }
}
