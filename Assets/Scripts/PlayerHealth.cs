using UnityEngine;
using System.Collections;

public class PlayerHealth : Health {

    public delegate void HealthUpdate();
    public static event HealthUpdate OnHealthUpdated;

    public int GetHealth { get { return health; } }

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