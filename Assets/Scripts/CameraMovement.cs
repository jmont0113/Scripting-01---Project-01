using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject playerToFollow;  //This is the player object this camera will follow 
    Vector3 cameraOffset;  //Offset to save, used for camera position readjustment 

    // Start is called before the first frame update
    void Start()
    {
         //Calculate the offset   
         cameraOffset = transform.position - playerToFollow.transform.position;
    }

    void LateUpdate()
    {
        if (playerToFollow == null)
        {
            playerToFollow = GameObject.Find("SpaceShip(Clone)");
        }
        else
        {
            //Readjust camera position off of player + offset position 
            transform.position = playerToFollow.transform.position + cameraOffset;
        }   
    }
}
