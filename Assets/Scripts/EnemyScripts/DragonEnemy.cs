using UnityEngine;
using System.Collections;

public class DragonEnemy : Enemy {

    //the speed of the up and down movement
    [SerializeField]
    private float waveSpeed;
    //the extent of the up and down movement
    [SerializeField]
    private float waveScale;

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
	}

    public override void Move()
    {
        //move the dragon using a left and modify the vertical movement with a sine wave
        rb.velocity = new Vector2(-1 * speed, Mathf.Sin(Time.time * waveSpeed) * waveScale);
    }
}