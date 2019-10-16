using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShining : MonoBehaviour
{
    public float Fluctuation;

    Light lightShine;
    float startIntencity;
    
    private void Start()
    {
        lightShine = gameObject.GetComponent<Light>();
        startIntencity = lightShine.intensity;
    }

    private void Update()
    {
        lightShine.intensity = startIntencity + Random.value * Fluctuation;
    }

}
