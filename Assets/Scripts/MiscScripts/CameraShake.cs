using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    //bool that determines whether or not the camera should shake
    private bool isShaking;

    //the "power" of the shake
    [SerializeField]
    private float scale;
    //the speed of the shake
    [SerializeField]
    private float speed;
    //the amount of time that the shake will occur
    [SerializeField]
    private float shakeTime;

    //the value that shakes the camera (uses the scale and speed variables)
    private float force;

    //variable used to help determine when to stop shaking
    private float timer;

    //the cameras initial rotation
    private Vector3 initialRotation;

    //the rotation that the camera will "lerp" towards
    private Quaternion newRotation;

    //bool that determines if the player has been hit (and therefore whether or not a shake should occur)
    private bool hit;

    // Use this for initialization
    void Start()
    {
        isShaking = false;

        hit = false;

        //set the initialRotation to the transforms rotation at the start of the game
        initialRotation = transform.rotation.eulerAngles;

        //newRotation set to the "default" quaternion 
        newRotation = Quaternion.identity;
    }

    void OnEnable()
    {
        //adds the method BeenHit to the event OnShakeCamera so that this script is notified whenever the player hits an enemy or is hit themselves
        EnemyHealth.OnShakeCamera += BeenHit;
    }

    // Update is called once per frame
    void Update()
    {
        //use a sin wave on the variable force in order to create the back and forth shake movement
        force = Mathf.Sin(Time.time * speed) * scale;

        //if the player has hit an enemy or been hit...
        if (hit)
        {
            //...then start shaking
            isShaking = true;
            //increment the timer
            timer += Time.smoothDeltaTime;
            //if the timer is over the amount of time it should shake...
            if(timer > shakeTime)
            {
                //...set the timer to 0
                timer = 0;
                //and stop saying the player has been hit
                hit = false;
            }

        }
        else if (!hit)
        {
            isShaking = false;
        }

        if (isShaking)
        {
            //interpolate between the current rotation and the force variable
            newRotation.z = Mathf.Lerp(newRotation.z, force, 1.0f);
            transform.rotation = newRotation;
        }
        else
        {
            //if the camera should stop shaking then "slerp" back to the initial rotation
            newRotation.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, initialRotation, 1.0f);
            transform.rotation = newRotation;
        }

        transform.position = Camera.main.transform.position;

    }

    void OnDisable()
    {
        EnemyHealth.OnShakeCamera -= BeenHit;
    }

    void BeenHit()
    {
        hit = true;
    }
}