using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPosition;
    [SerializeField]
    private int pooledAmount = 30;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private bool singleShot;
    
    public bool SingleShot { get { return singleShot; } }  

    private float nextFire;

    private List<GameObject> bullets;

    private Rigidbody2D rb;
    private Collider2D col;

    private Rigidbody2D bulletRb;
    private Collider2D bulletCol;

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
            GameObject b = (GameObject)Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            bulletRb = b.GetComponent<Rigidbody2D>();
            bulletCol = b.GetComponent<Collider2D>();
            b.SetActive(false);
            bullets.Add(b);
        }
	}

    public void Fire()
    {
        if (gameObject.activeSelf && Time.timeScale > 0.1f)
        {
            if (Time.time > nextFire)
            {

                nextFire = Time.time + fireRate;

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
        }
    }

    public void BurstFire()
    {
        if (gameObject.activeSelf && Time.timeScale > 0.1f)
        {
            if (Time.time > nextFire)
            {

                nextFire = Time.time + fireRate;

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