﻿using UnityEngine;
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

    private Vector2 mobileInput;

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

    void Update()
    {

        for (int i = 0; i < Input.touches.Length; i++)
        {
            if (Input.touches[i].phase == TouchPhase.Moved)
            {
                mobileInput = Input.touches[i].deltaPosition.normalized;
            }
            else if(Input.touches[i].phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

	void FixedUpdate()
	{
        //The horizontal and vertical input from the player
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        //Set the velocity of the player according to their input multiplied by a speed variable
        //rb.velocity = new Vector2(xInput * speed, yInput * speed);
        rb.velocity = new Vector2(mobileInput.x * speed, mobileInput.y * speed);

        //The position is clamped between the boundary class values
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<IPowerup>() != null)
        {
            other.GetComponent<IPowerup>().ApplyPowerup();
            other.GetComponent<IPowerup>().DestroyPowerup();
        }
    }
}