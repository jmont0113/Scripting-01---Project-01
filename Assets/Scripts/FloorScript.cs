using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{

   void OnCollisionEnter()
    {
        Debug.Log("Detected Dynamic Collider");
    }

    void OnCollionStay()
    {
        Debug.Log("Still touching the Dynamic Collider!");
    }

    void OnCollisionExit()
    {
        Debug.Log("Dynamic object has left the floor...");
    }
}
