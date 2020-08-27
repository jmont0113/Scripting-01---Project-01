using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Color lightColor;
    public float lightIntensity;

    Light light;

    //Fill references 
    void Awake()
    {
        light = GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        light.enabled = true;
        light.color = lightColor;
        light.intensity = lightIntensity;

    }
}
