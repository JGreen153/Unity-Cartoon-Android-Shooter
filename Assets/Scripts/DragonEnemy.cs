using UnityEngine;
using System.Collections;

public class DragonEnemy : Enemy {

    [SerializeField]
    private float speed;

    [SerializeField]
    private float waveSpeed;
    [SerializeField]
    private float waveScale;

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
        Move();

        if (transform.position.x < -12.0f)
        {
            Die();
        }
    }

    public void Move()
    {
        rb.velocity = new Vector2(-1 * speed, Mathf.Sin(Time.time * waveSpeed) * waveScale);
    }
}