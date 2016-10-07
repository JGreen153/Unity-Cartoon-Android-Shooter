using UnityEngine;
using System.Collections;

public class ButtonMovement : MonoBehaviour {

    private GameObject player;

    private PlayerMovement playerMoveScript;
    private PlayerShoot playerShootScript;

    // Use this for initialization
	void Start() 
	{
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null)
            player = p;

        playerMoveScript = player.GetComponent<PlayerMovement>();
        playerShootScript = player.GetComponent<PlayerShoot>();
	}

    public void MoveUp()
    {
        playerMoveScript.MoveUp();
    } 

    public void MoveDown()
    {
        playerMoveScript.MoveDown();
    }

    public void Shoot()
    {
        if (playerShootScript.SingleShot)
            playerShootScript.Fire();
        else
            playerShootScript.BurstFire();
    }
	
}