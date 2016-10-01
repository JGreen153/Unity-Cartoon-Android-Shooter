using UnityEngine;
using System.Collections;

public class DragonEnemy : Enemy {

    [SerializeField]
    private float waveSpeed;
    [SerializeField]
    private float waveScale;

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
	}

    public override void Move()
    {
        rb.velocity = new Vector2(-1 * speed, Mathf.Sin(Time.time * waveSpeed) * waveScale);
    }
}