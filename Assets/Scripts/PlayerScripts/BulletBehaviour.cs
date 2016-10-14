using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;

    //the damage that the projectile will do to the enemy, along with a getter
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    //the speed of the projectile
    [SerializeField]
    private float speed;
    //the time until the bullet is disabled
    [SerializeField]
    private float timeUntilDestruction;

    //the explosion that will appear on the screen
    [SerializeField]
    private GameObject explosionPrefab;
    //a variable that holds the explosionPrefab and is enabled whenever an explosion occurs and disabled shortly after
    private GameObject explosion;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //instantiate the explosionPrefab and assign explosion to it
        explosion = Instantiate(explosionPrefab);
        explosion.SetActive(false);
    }

    void OnEnable()
    {
        //when the bullet is active disable it in timeUntilDestruction seconds
        Invoke("Destroy", timeUntilDestruction);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //have the bullet constantly move forward
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //when it collides with anything it disables itself, moves and rotates the explosion to its own position and rotation and then activates the explosion
        Destroy();
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
        explosion.SetActive(true);

        //it then disables the explosion in 0.5f seconds to give the explosion time to animate and look cool
        Invoke("Disable", 0.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if it hits a powerup then apply the powerup and destroy it
        if (other.GetComponent<IPowerup>() != null)
        {
            other.GetComponent<IPowerup>().ApplyPowerup();
            other.GetComponent<IPowerup>().DestroyPowerup();
        }
    }

    void Disable()
    {
        explosion.SetActive(false);
    }
}