using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShining : MonoBehaviour
{
    Light lightShine;
    float startIntencity;

    private void Start()
    {
        lightShine = gameObject.GetComponent<Light>();
        startIntencity = lightShine.intensity;
    }

    private void Update()
    {
        lightShine.intensity = startIntencity + Random.value * 3;
    }

}
