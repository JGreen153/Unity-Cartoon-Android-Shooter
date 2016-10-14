using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    protected Rigidbody2D rb;

    //speed of the enemies movement
    [SerializeField]
    protected float speed;

    //the damage that the enemy deals when it hits the player
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    void FixedUpdate()
    {
        Move();

        //if the enemy has moved off the screen to the left then...
        if (transform.position.x < -12.0f)
        {
            //...disable them and move them back to the centre of the screen 
            Despawn();
        }
    }

    public virtual void Move()
    {
        //move the enemy left
        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
        transform.position = Vector2.zero;
    }
}