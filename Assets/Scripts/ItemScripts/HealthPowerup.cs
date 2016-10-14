using UnityEngine;
using System.Collections;

public class HealthPowerup : MonoBehaviour, IPowerup {

    //delegate/event to update the healthUI
    public delegate void HealthUpdate();
    public static event HealthUpdate OnHealthUpdated;

    //the player
    private PlayerHealth player;

    //sound to play when the powerup is used
    private AudioSource powerUpSound;

    // Use this for initialization
	void Start() 
	{
        powerUpSound = GetComponent<AudioSource>();

        //local variable p gets the player
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        //if p isn't null then set player equal to p's PlayerHealth component
        if (p != null)
            player = p.GetComponent<PlayerHealth>();
	}

    void Update()
    {
        //if the powerup has fallen below the screen then destroy it
        if(transform.position.y < -4.8f)
        {
            DestroyPowerup();
        }
    }

    public void ApplyPowerup()
    {
        player.Heal();

        powerUpSound.Play();

        //if delegate/event isn't null then call it
        if (OnHealthUpdated != null)
            OnHealthUpdated();
    }

    public void DestroyPowerup()
    {
        //disable the powerup in 0.15f seconds (to allow the powerup sfx to play)
        Invoke("Disable", 0.15f);
    }

    void Disable()
    {
        gameObject.SetActive(false);
        transform.position = Vector2.zero;
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}