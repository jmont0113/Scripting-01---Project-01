using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.transform.position = respawnPoint.transform.position;
            
            gameObject.SetActive(true);
        }
    }

}