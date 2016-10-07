using UnityEngine;
using System.Collections;

public abstract class Health : MonoBehaviour {

    [SerializeField]
    protected int health;

    private int initialHealth;

    [SerializeField]
    private GameObject explosionPrefab;
    private GameObject explosion;

    protected bool isDead;

    void Awake()
    {
        isDead = false;

        initialHealth = health;

    }

    void Start()
    {
        explosion = Instantiate(explosionPrefab);
        explosion.SetActive(false);
    }

    void OnEnable()
    {
        isDead = false;
        health = initialHealth;
    }

    void Update()
    {
        if (health <= 0 && !isDead)
        {
            Die();
        }

        if (health < 0)
            health = 0;
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    public void Damage(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        isDead = true;
        health = 0;
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
        explosion.SetActive(true);
        gameObject.SetActive(false);

        Invoke("Disable", 0.5f);
    }

    public void Disable()
    {
        explosion.SetActive(false);
    }
}