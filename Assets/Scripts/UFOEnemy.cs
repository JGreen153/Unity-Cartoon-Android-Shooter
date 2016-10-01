using UnityEngine;
using System.Collections;

public class UFOEnemy : Enemy {

    private Transform player;

    private bool facingLeft;

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        speed = Random.Range(speed - 1, speed + 1);

        facingLeft = true;
	}

    void OnEnable()
    {
        facingLeft = true;
    }

    public override void Move()
    {
        Vector3 target = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(target.x, target.y) * speed;

        if(target.x > 0 && facingLeft)
        {
            Flip();
        }
        else if(target.x < 0 && !facingLeft)
        {
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