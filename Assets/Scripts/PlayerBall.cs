using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerBall : MonoBehaviour
{

    public float moveSpeed = 5.0f; //Player movement speed

    public float speedIncreaseDuration = 2.5f; // Duration in seconds of speed increase

    float speedIncreaseTimer = 0; //Timer counts down to track speed duration

    Rigidbody rigidbody;

    private void Awake()
    {
        //Caching
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Count down the time, do our checks
        UpdateTimer();
    }

    private void FixedUpdate()
    {
        //Calculate input amount
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Combine movement calculations into a vector 
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        //Add the vector force 
        rigidbody.AddForce(movement * moveSpeed);
    }

    void UpdateTimer()
    {
        if(speedIncreaseTimer > 0)
        {
            //Keep counting, still have time left 
            speedIncreaseTimer -= Time.deltaTime;
            //Fringe Case - If we (VERY RARELY) count down directly to 0, also Return speed
            if(speedIncreaseTimer == 0)
            {
                ReturnSpeed();
            }
        }

        if(speedIncreaseTimer < 0)
        {
            //We're out of time! Stop the timer
            ReturnSpeed();
        }
    }

    //Increases player speed by an amount
    public void IncreaseSpeed(float increaseAmount)
    {
        Debug.Log("Increase player speed by " + increaseAmount);
        //Do logaic to increase player Speed
        //Visual Feedback
        //AudioFeedback
        //Start the timer!
        speedIncreaseTimer = speedIncreaseDuration;
    }

    //Return player to original speed, stop the speed increase timer
    public void ReturnSpeed()
    {
        //Stop timer
        //
        speedIncreaseTimer = 0;
        Debug.Log("RETURN SPEED");
    }
}
