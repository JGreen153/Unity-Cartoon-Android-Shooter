using UnityEngine;
using System.Collections;

public class HealthPowerup : MonoBehaviour, IPowerup {

    public delegate void HealthUpdate();
    public static event HealthUpdate OnHealthUpdated;

    private PlayerHealth player;

    private AudioSource powerUpSound;

    // Use this for initialization
	void Start() 
	{
        powerUpSound = GetComponent<AudioSource>();

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null)
            player = p.GetComponent<PlayerHealth>();
	}

    void Update()
    {
        if(transform.position.y < -4.8f)
        {
            DestroyPowerup();
        }
    }

    public void ApplyPowerup()
    {
        player.Heal();

        powerUpSound.Play();

        if (OnHealthUpdated != null)
            OnHealthUpdated();
    }

    public void DestroyPowerup()
    {
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