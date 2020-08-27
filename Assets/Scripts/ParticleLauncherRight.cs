using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncherRight : MonoBehaviour
{
    [SerializeField] ParticleSystem particleLauncherRight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            particleLauncherRight.Emit(1);
        }

    }
}
