using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] float speedIncreaseAmount = 2.5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //DoThing
            PlayerBall playerBall = other.gameObject.GetComponent<PlayerBall>();
            //if we found the PlayerBall, run the function
            if (playerBall != null)
            {
                playerBall.IncreaseSpeed(speedIncreaseAmount);
            }
            //Disable this object
            gameObject.SetActive(false);
        }
    }
}