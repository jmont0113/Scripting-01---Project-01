using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncherLeft : MonoBehaviour
{
    [SerializeField] ParticleSystem particleLauncherLeft;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            particleLauncherLeft.Emit(1);
        }
    }
}
