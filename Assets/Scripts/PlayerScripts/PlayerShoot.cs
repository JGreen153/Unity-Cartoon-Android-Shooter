using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour {

    //the projectile that will be fired
    [SerializeField]
    private GameObject bulletPrefab;
    //the position that it will be fired from
    [SerializeField]
    private Transform bulletPosition;
    //the amount of projectiles instantiated as the game starts up
    [SerializeField]
    private int pooledAmount = 30;
    //controls the players rate of fire
    [SerializeField]
    private float fireRate;
    //is the ship firing projectiles in a burst or single-shot rhythm
    [SerializeField]
    private bool singleShot;
    
    public bool SingleShot { get { return singleShot; } }  

    //helps define the fire rate
    private float nextFire;

    //list containing all the bullets instantiated
    private List<GameObject> bullets;

    //the player's rigidbody and collider
    private Rigidbody2D rb;
    private Collider2D col;

    //the projectiles rigidbody and collider
    private Rigidbody2D bulletRb;
    private Collider2D bulletCol;

    //the time between each of the bullets fired in the burst
    private float burstTime;

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        bullets = new List<GameObject>();

        burstTime = .1f;

        for (int i = 0; i < pooledAmount; i++)
        {
            //instantiate an amount of projectiles based on the pooledAmount variable
            GameObject b = (GameObject)Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            //get the rigidbodies and colliders of each projectile
            bulletRb = b.GetComponent<Rigidbody2D>();
            bulletCol = b.GetComponent<Collider2D>();
            //disable the objects and add them to the list
            b.SetActive(false);
            bullets.Add(b);
        }
	}

    public void Fire()
    {
        //if the player isn't destroyed and the game isn't paused...
        if (gameObject.activeSelf && Time.timeScale > 0.1f)
        {
            //...check that enough time has passed for the player to shoot
            if (Time.time > nextFire)
            {
                //set nextFire to the current time + fireRate to set the amount of time that must pass before the player can fire their next shot
                nextFire = Time.time + fireRate;

                for (int i = 0; i < bullets.Count; i++)
                {
                    //loop through all the projectiles and check that they're active
                    if (!bullets[i].activeInHierarchy)
                    {
                        //if they are active then set the position and rotation to the bulletPosition variable and the players rotation respectively
                        bullets[i].transform.position = bulletPosition.position;
                        bullets[i].transform.rotation = transform.rotation;
                        //make the projectiles ignore collisions between themselves and the player
                        Physics2D.IgnoreCollision(bulletCol, col);
                        //set the velocity to the players velocity so the speed of the bullet is consistent with the player's movement
                        bulletRb.velocity = rb.velocity;
                        bullets[i].SetActive(true);
                        break;
                    }
                }
            }
        }
    }

    public void BurstFire()
    {
        //this method works the same as fire apart from...
        if (gameObject.activeSelf && Time.timeScale > 0.1f)
        {
            if (Time.time > nextFire)
            {

                nextFire = Time.time + fireRate;

                //...this part where I call the Burst method (mostly the same as the fire method) and then invoke it twice after using the
                //burstTime variable to delay the extra shots
                Burst();
                Invoke("Burst", burstTime);
                Invoke("Burst", burstTime * 2);
            }
        }
    }

    void Burst()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = bulletPosition.position;
                bullets[i].transform.rotation = transform.rotation;
                Physics2D.IgnoreCollision(bulletCol, col);
                bulletRb.velocity = rb.velocity;
                bullets[i].SetActive(true);
                break;
            }
        }
    }

    void OnDisable()
    {
        CancelInvoke();
    }

}