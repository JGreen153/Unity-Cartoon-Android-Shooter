using UnityEngine;
using System.Collections;

public class PlayerHealth : Health {

    //delegate/event to broadcast changes to the players health
    public delegate void HealthUpdate();
    public static event HealthUpdate OnHealthUpdated;

    //delegate/event to stop the timer
    public delegate void TimeStopped();
    public static event TimeStopped OnTimeStopped;

    //some getters that return the players health and some information on whether or not they're dead
    public int GetHealth { get { return health; } }
    public bool PlayerIsDead { get { return isDead; } }

    void Update()
    {
        //if the players health is less than 0 and they're not dead...
        if (health <= 0 && !isDead)
        {
            //...then kill them
            Die();
        }

        //if the player is dead...
        if (isDead)
        {
            //...call the event/delegate to stop the timer
            if (OnTimeStopped != null)
                OnTimeStopped();
        }

    }

    public void Heal()
    {
        //if players health is less than 80 then add 20, otherwise set it to 100
        if (health <= 80)
            health += 20;
        else
            health = 100;
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        //if theres been a collision and it was an enemy...
        if(other.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            //...then deal the damage if the player should survive it and set the health to 0 if they shouldn't
            if (health - enemy.Damage >= 0)
                Damage(enemy.Damage);
            else
                health = 0;

            //update the health ui and finish manager
            if (OnHealthUpdated != null)
                OnHealthUpdated();
        }
    }
}