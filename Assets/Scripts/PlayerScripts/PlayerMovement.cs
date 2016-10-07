using UnityEngine;
using System.Collections;

//Class made to define movement boundaries
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerMovement : MonoBehaviour {

    //Rigidbody attached to the script
    private Rigidbody2D rb;

    //The speed of the players movement
    [SerializeField]
    private float speed = 4;

    [SerializeField]
    private Boundary boundary;

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
        //The position is clamped between the boundary class values
        rb.position = new Vector2(-5.0f, Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
	}

    public void MoveUp()
    {
        if (IsInvoking("Stop"))
            CancelInvoke();

        rb.velocity = new Vector2(rb.velocity.x, 0.0f);
        rb.velocity += Vector2.up * speed;

        Invoke("Stop", 0.3f);
    }

    public void MoveDown()
    {
        if (IsInvoking("Stop"))
            CancelInvoke();

        rb.velocity = new Vector2(rb.velocity.x, 0.0f);
        rb.velocity += Vector2.down * speed;

        Invoke("Stop", 0.3f);
    }

    public void Stop()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<IPowerup>() != null)
        {
            other.GetComponent<IPowerup>().ApplyPowerup();
            other.GetComponent<IPowerup>().DestroyPowerup();
        }
    }

    void OnDisable()
    {
        CancelInvoke();
    }

}