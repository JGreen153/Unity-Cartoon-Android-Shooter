using UnityEngine;
using System.Collections;

public class EnemyHealth : Health
{
    //delegate and an event to let the game know when to update the score
    public delegate void UpdateScore();
    public static event UpdateScore OnUpdateScore;

    //delegate and an event to let the game know when to shake the camera
    public delegate void ShakeCamera();
    public static event ShakeCamera OnShakeCamera;

    //the score that the enemy adds to the player's score when hit
    [SerializeField]
    private int enemyScore;

    void OnCollisionEnter2D(Collision2D other)
    {
        //If the enemies collides with the player/an object that uses the PlayerMovement class...
        if(other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if (OnShakeCamera != null)
                OnShakeCamera();

            //..then it will die 
            Die();
        }

        //If the enemies collides with a bullet...
        if (other.gameObject.GetComponent<BulletBehaviour>() != null)
        {
            //...then deal damage to the enemy according to the bullets damage variable in its class
            Damage(other.gameObject.GetComponent<BulletBehaviour>().Damage);

            //if the players score would be under the winning score after hitting an enemy then increase the score normally...
            if (PlayerScore.score + enemyScore < FinishManager.ScoreToWin)
            {
                PlayerScore.score += enemyScore;
            }
            //...however if the end result is more than the winning score then set the players score equal to it
            else if (PlayerScore.score + enemyScore >= FinishManager.ScoreToWin)
            {
                PlayerScore.score = FinishManager.ScoreToWin;
            }

            //call the event/delegate to update the score
            if (OnUpdateScore != null)
                OnUpdateScore();

            //call the event/delegate to inform the game on when to shake the camera
            if (OnShakeCamera != null)
                OnShakeCamera();
        }

        //if the enemy hits an explosion from the rocket...
        if(other.gameObject.GetComponent<RocketExplosion>() != null)
        {
            //...deal one damage (highest enemy health is 3)
            Damage(1);

            //same as above except increases the score by the enemyscore variable divided by 2
            if (PlayerScore.score + enemyScore / 2 < FinishManager.ScoreToWin)
            {
                PlayerScore.score += enemyScore / 2;
            }
            else if (PlayerScore.score + enemyScore / 2 >= FinishManager.ScoreToWin)
            {
                PlayerScore.score = FinishManager.ScoreToWin;
            }

            if (OnUpdateScore != null)
                OnUpdateScore();

            if (OnShakeCamera != null)
                OnShakeCamera();
        }
    }
}
