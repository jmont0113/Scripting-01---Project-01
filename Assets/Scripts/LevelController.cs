using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioClip))]

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioClip feedbackSound;

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
           AudioSource.PlayClipAtPoint(feedbackSound, new Vector3(5, 1, 2));
        }

        if (Input.GetKey(KeyCode.S))
        {
            AudioSource.PlayClipAtPoint(feedbackSound, new Vector3(5, 1, 2));
        }

        if (Input.GetKey(KeyCode.D))
        {
            AudioSource.PlayClipAtPoint(feedbackSound, new Vector3(5, 1, 2));
        }

        if (Input.GetKey(KeyCode.A))
        {
            AudioSource.PlayClipAtPoint(feedbackSound, new Vector3(5, 1, 2));
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}