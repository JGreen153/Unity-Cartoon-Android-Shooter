using UnityEngine;
using System.Collections;

public class CruncherEnemy : Enemy {

    [SerializeField]
    private float speed;

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
        Move();

        if(transform.position.x < -12.0f)
        {
            Die();
        }
	}

    public void Move()
    {
        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
    }
}