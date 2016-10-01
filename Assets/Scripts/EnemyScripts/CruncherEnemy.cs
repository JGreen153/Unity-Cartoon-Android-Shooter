using UnityEngine;
using System.Collections;

public class CruncherEnemy : Enemy {

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
	}
}