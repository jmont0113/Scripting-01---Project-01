using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject player;
    Vector3 miniMap;

    private void Start()
    {
        miniMap = player.transform.position;
    }

    private void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.Find("SpaceShip(Clone)");
        }

        else
        {
            transform.position = player.transform.position;
        }
    }
}