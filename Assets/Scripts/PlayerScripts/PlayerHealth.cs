using UnityEngine;
using System.Collections;

public class PlayerHealth : Health {

    public delegate void HealthUpdate();
    public static event HealthUpdate OnHealthUpdated;

    public delegate void TimeStopped();
    public static event TimeStopped OnTimeStopped;

    public int GetHealth { get { return health; } }
    public bool PlayerIsDead { get { return isDead; } }

    void Update()
    {
        if (health <= 0 && !isDead)
        {
            Die();
        }

        if (isDead)
        {
            if (OnTimeStopped != null)
                OnTimeStopped();
        }

    }

    public void Heal()
    {
        if (health <= 80)
            health += 20;
        else
            health = 100;
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (health - enemy.Damage >= 0)
                Damage(enemy.Damage);
            else
                health = 0;

            if (OnHealthUpdated != null)
                OnHealthUpdated();
        }
    }
}