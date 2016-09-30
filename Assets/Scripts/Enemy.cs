using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    protected Rigidbody2D rb;

    public void Die()
    {
        gameObject.SetActive(false);
        transform.position = Vector2.zero;
    }
}