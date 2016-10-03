using UnityEngine;
using System.Collections;

public class HealthPowerup : MonoBehaviour, IPowerup {

    public delegate void HealthUpdate();
    public static event HealthUpdate OnHealthUpdated;

    private PlayerHealth player;

    // Use this for initialization
	void Start() 
	{
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

        if (OnHealthUpdated != null)
            OnHealthUpdated();
    }

    public void DestroyPowerup()
    {
        gameObject.SetActive(false);
        transform.position = Vector2.zero;
    }
}