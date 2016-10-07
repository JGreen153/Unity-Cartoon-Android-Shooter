using UnityEngine;
using System.Collections;

public class UFOEnemy : Enemy {

    private Transform player;

    private bool facingLeft;

    void Awake()
    {
        Transform p = GameObject.FindGameObjectWithTag("Player").transform;

        if (p != null)
            player = p;
    }

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();

        facingLeft = true;
	}

    void OnEnable()
    {
        if (!facingLeft)
            Flip();
    }

    public override void Move()
    {
        if (player != null)
        {
            Vector3 target = (player.position - transform.position).normalized;

            rb.velocity = new Vector2(-1 * speed, target.y);

            if (target.x < 0 && facingLeft)
                Flip();
            else if (target.x > 0 && !facingLeft)
                Flip();
            
        }
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}