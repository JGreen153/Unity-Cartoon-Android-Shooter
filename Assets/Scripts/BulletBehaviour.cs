using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    private Rigidbody2D rb;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeUntilDestruction;

    void OnEnable()
    {
        Invoke("Destroy", timeUntilDestruction);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    // Use this for initialization
	void Start() 
	{
        rb = GetComponent<Rigidbody2D>();
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
}