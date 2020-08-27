using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] float multipler = 3.0f; 
    [SerializeField] float duration = 5.0f; 

    [SerializeField] ParticleSystem PowerupParticleSystem;
    [SerializeField] AudioSource pickUp;
    [SerializeField] AudioSource powerUp;
    [SerializeField] AudioSource powerDown;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other) );
        }
    }

    IEnumerator Pickup(Collider player)
    {
        //Spawn a cool effect
        PowerupParticleSystem.Play();

        pickUp.Play();
        //Apply effect to the player
        player.transform.localScale *= multipler;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        powerUp.Play();

        //Wait x amount of seconds

        yield return new WaitForSeconds(duration);

        powerDown.Play();
        //Reverse the effect on our player 
        player.transform.localScale /= multipler;
    }
}
