using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateGameObject : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float secondsUntilDestroy = 2.0f;
    [SerializeField] ParticleSystem hazardParticle;
    [SerializeField] GameObject deathUI;
    [SerializeField] float quick = 0.1f;
    [SerializeField] CameraShake cameraShake;
    [SerializeField] AudioSource feedbackAudio;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            feedbackAudio.Play();
            StartCoroutine(cameraShake.Shake(.2f, 5f)); //.15 .4
            StartCoroutine(playerDeath());
            StartCoroutine(returnPlayer());
        }

        IEnumerator returnPlayer()
        {
            hazardParticle.Play();
            yield return new WaitForSeconds(secondsUntilDestroy);
            GameObject newSpawn = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }

        IEnumerator playerDeath()
        {
            deathUI.SetActive(true);
            yield return new WaitForSeconds(quick);
            deathUI.SetActive(false);
        }
    }
}
