using UnityEngine;
using System.Collections;

public class RocketExplosion : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the explosion from the rocket hits a powerup then apply the powerup and then destroy it
        if (other.GetComponent<IPowerup>() != null)
        {
            other.GetComponent<IPowerup>().ApplyPowerup();
            other.GetComponent<IPowerup>().DestroyPowerup();
        }
    }

}