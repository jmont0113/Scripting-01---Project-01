using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncherFoward : MonoBehaviour
{
    [SerializeField] ParticleSystem particleLauncherFoward;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            particleLauncherFoward.Emit(1);
        }
    }
}
