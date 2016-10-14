using UnityEngine;
using System.Collections;

public class ButtonMovement : MonoBehaviour {

    private GameObject player;

    //the scripts that control the players movement and shooting respectively
    private PlayerMovement playerMoveScript;
    private PlayerShoot playerShootScript;

    // Use this for initialization
	void Start() 
	{
        //a local variable to get the player
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        //if the player is in the scene then assign player to the local variable
        if (p != null)
            player = p;

        //assign the variables to the players movement and shooting scripts so I can use certain methods
        playerMoveScript = player.GetComponent<PlayerMovement>();
        playerShootScript = player.GetComponent<PlayerShoot>();
	}

    public void MoveUp()
    {
        //calls the method to move the player up
        playerMoveScript.MoveUp();
    } 

    public void MoveDown()
    {
        //calls the method to move the player down
        playerMoveScript.MoveDown();
    }

    public void Shoot()
    {
        //if the ship is a single shot ship then call the standard fire method, otherwise call the burst shot method
        if (playerShootScript.SingleShot)
            playerShootScript.Fire();
        else
            playerShootScript.BurstFire();
    }
	
}