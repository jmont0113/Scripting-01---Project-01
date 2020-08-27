using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField] float duration = 2.0f;
    [SerializeField] ParticleSystem PowerupParticleSystem;

    private float slowDownFactor = 0.5f;
    private float deactivationPeriodDuration = 1.0f;

    private float deactivationElapsedTime;
    private float endEffect;

    [SerializeField] AudioSource pickUp;
    [SerializeField] AudioSource powerUp;
    [SerializeField] AudioSource powerDown;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            endEffect = Time.time + duration;
            StartCoroutine(SlowDown());
        }
    }

    IEnumerator SlowDown()
    {
        PowerupParticleSystem.Play();
        pickUp.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Time.timeScale = slowDownFactor;
        powerUp.Play();
        while (Time.time < endEffect)
        {
            yield return null;
        }

        deactivationElapsedTime = 0;
        powerDown.Play();
        while (deactivationElapsedTime < deactivationPeriodDuration)
        {
            Time.timeScale = Mathf.Lerp(slowDownFactor, 1, (deactivationElapsedTime / deactivationPeriodDuration));
            deactivationElapsedTime += Time.deltaTime;
            yield return null;
        }
        
        Time.timeScale = 1;
    }

}
