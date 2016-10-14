using UnityEngine;
using System.Collections;

public class UFOEnemy : Enemy {

    //The transform of the player which the enemy will move towards
    private Transform player;

    //boolean to see if it's facing forward
    private bool facingLeft;

    void Awake()
    {
        //local variable to get the players transform via tag
        Transform p = GameObject.FindGameObjectWithTag("Player").transform;

        //If p isn't null (if the player is in the scene) then set the player variable to p
        if (p != null)
            player = p;
    }

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();

        //start facing forward
        facingLeft = true;
	}

    void OnEnable()
    {
        //if not facing forward when enabled then flip
        if (!facingLeft)
            Flip();
    }

    public override void Move()
    {
        //check if the player is not destroyed
        if (player != null)
        {
            //get the difference between the player and this objects position and normalise to get the direction
            Vector3 target = (player.position - transform.position).normalized;

            //set the objects velocity to constantly go left while adjusting height to slowly move towards the player
            rb.velocity = new Vector2(-1 * speed, target.y);

            //if the player is behind you and you're facing left then turn around...
            if (target.x < 0 && facingLeft)
                Flip();
            //...and vice versa
            else if (target.x > 0 && !facingLeft)
                Flip();
            
        }
    }

    void Flip()
    {
        //the direction they are facing is flipped
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        //multiplies the scale by -1 so it flips
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}