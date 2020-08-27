using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncherBackwards : MonoBehaviour
{
    [SerializeField] ParticleSystem particleLauncherBackwards;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            particleLauncherBackwards.Emit(1);
        }

    }
}
