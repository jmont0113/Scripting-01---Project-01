using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] float duration = 5.0f;
    [SerializeField] float quick = 0.1f;
    [SerializeField] TrailRenderer trailRenderer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Powerup") //uses a tag to change to player
        {
            StartCoroutine(changeColor());
        }

        IEnumerator changeColor()
        {
            Color randomlySelectedColor = Color.red;
            GetComponent<Renderer>().material.color = randomlySelectedColor;

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
}
