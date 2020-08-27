using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePowerUp : MonoBehaviour
{
    [SerializeField] ParticleSystem PowerupParticleSystem;
    [SerializeField] AudioSource pickUp;
    [SerializeField] AudioSource powerUp;
    [SerializeField] AudioSource powerDown;

    [SerializeField] float duration = 5.0f;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(collecting());
        }

        IEnumerator collecting()
        { 
            pickUp.Play();
            PowerupParticleSystem.Play();

            powerUp.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(duration);

            powerDown.Play();
        }
    }
}

