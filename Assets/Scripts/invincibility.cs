using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibility : MonoBehaviour
{
    [SerializeField] float duration = 5.0f;
    [SerializeField] float quick = 0.1f;
    [SerializeField] GameObject wing;
    [SerializeField] TrailRenderer trailRenderer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "invincibility") //uses a tag to change to player
        {
            StartCoroutine(invincibilityStatus(other));
        }
    }

    IEnumerator invincibilityStatus(Collider player)
    {
        GetComponent<BoxCollider>().enabled = false;
        trailRenderer.enabled = true;
        wing.SetActive(true);
        yield return new WaitForSeconds(duration);
        Color flashColor = Color.white;
        GetComponent<Renderer>().material.color = flashColor;

        yield return new WaitForSeconds(quick);
        trailRenderer.enabled = false;
        Color regColor = Color.yellow;
        GetComponent<Renderer>().material.color = regColor;

        wing.SetActive(false);

        GetComponent<BoxCollider>().enabled = true;

    }
}
