using UnityEngine;
using System.Collections;

public class CreditScroller : MonoBehaviour {

    //the speed that the credits will scroll at
    [SerializeField]
    private float scrollSpeed;

    //the point where the credits will stop scrolling
    [SerializeField]
    private float stoppingPoint;

	// Update is called once per frame
	void Update()
	{
        //if the credits are below the stoppingPoint then move upwards
        if (transform.position.y < stoppingPoint)
            transform.position += Vector3.up * scrollSpeed;
	}
}