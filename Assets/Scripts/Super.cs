using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : MonoBehaviour
{
    [SerializeField] float duration = 5.0f;
    [SerializeField] float quick = 0.1f;
    [SerializeField] TrailRenderer trailRenderer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Super") //uses a tag to change to player
        {
            StartCoroutine(SuperStatus(other));
        }
    }

    IEnumerator SuperStatus(Collider player)
    {
        GetComponent<BoxCollider>().enabled = true;
        trailRenderer.enabled = true;
        yield return new WaitForSeconds(duration);

        Color flashColor = Color.white;
        GetComponent<Renderer>().material.color = flashColor;

        yield return new WaitForSeconds(quick);
        trailRenderer.enabled = false;
        Color regColor = Color.yellow;
        GetComponent<Renderer>().material.color = regColor;

    }
}
