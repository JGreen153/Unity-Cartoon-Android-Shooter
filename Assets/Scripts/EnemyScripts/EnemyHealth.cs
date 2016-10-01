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
            PlayerScore.score += enemyScore;

            if (OnUpdateScore != null)
                OnUpdateScore();
        }
    }
}
