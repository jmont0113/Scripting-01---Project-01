using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    [SerializeField] GameObject newObject;
    [SerializeField] Transform respawnArea;
    [SerializeField] float killTime = 2.0f;
    [SerializeField] ParticleSystem hazardParticle;
    [SerializeField] GameObject deathUI;
    [SerializeField] float quick = 0.1f;
    [SerializeField] CameraShake cameraShake;
    [SerializeField] AudioSource feedbackAudio;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            feedbackAudio.Play();
            StartCoroutine(cameraShake.Shake(.2f, 5f)); //.15 .4
            StartCoroutine(playerDeath());
            StartCoroutine(respawnPlayer());
        }

        IEnumerator respawnPlayer()
        {
            hazardParticle.Play();
            yield return new WaitForSeconds(killTime);
            GameObject newSpawn = Instantiate(newObject, respawnArea.position, respawnArea.rotation);
        }

        IEnumerator playerDeath()
        {
            deathUI.SetActive(true);
            yield return new WaitForSeconds(quick);
            deathUI.SetActive(false);
        }
    }
}
