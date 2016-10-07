using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeUntilDestruction;

    [SerializeField]
    private GameObject explosionPrefab;
    private GameObject explosion;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        explosion = Instantiate(explosionPrefab);
        explosion.SetActive(false);
    }

    void OnEnable()
    {
        Invoke("Destroy", timeUntilDestruction);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
        Destroy();
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
        explosion.SetActive(true);

        Invoke("Disable", 0.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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