using UnityEngine;
using System.Collections;

public class PlayerHealth : Health {

    public delegate void HealthUpdate();
    public static event HealthUpdate OnHealthUpdated;

    public delegate void TimeStopped();
    public static event TimeStopped OnTimeStopped;

    public int GetHealth { get { return health; } }

    void Update()
    {
        if (health <= 0 && !isDead)
        {
            Die();
        }

        health = Mathf.Clamp(health, 0, 100);

        if (isDead)
        {
            if (OnTimeStopped != null)
                OnTimeStopped();
        }

    }

    public void Heal()
    {
        health += 20;
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Enemy>() != null)
        {
            Damage(other.gameObject.GetComponent<Enemy>().Damage);

            if (OnHealthUpdated != null)
                OnHealthUpdated();
        }
    }
}