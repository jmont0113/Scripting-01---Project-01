using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player has just passed position " + other.gameObject.transform.position);
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
        }
    }
}
