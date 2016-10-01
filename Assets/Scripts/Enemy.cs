using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    protected Rigidbody2D rb;

    [SerializeField]
    protected float speed;

    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    void FixedUpdate()
    {
        Move();

        if (transform.position.x < -12.0f)
        {
            Despawn();
        }
    }

    public virtual void Move()
    {
        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
        transform.position = Vector2.zero;
    }
}