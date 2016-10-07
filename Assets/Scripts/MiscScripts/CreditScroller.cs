using UnityEngine;
using System.Collections;

public class CreditScroller : MonoBehaviour {

    [SerializeField]
    private float scrollSpeed;

    [SerializeField]
    private float stoppingPoint;

	// Update is called once per frame
	void Update()
	{
        if (transform.position.y < stoppingPoint)
            transform.position += Vector3.up * scrollSpeed;
	}
}