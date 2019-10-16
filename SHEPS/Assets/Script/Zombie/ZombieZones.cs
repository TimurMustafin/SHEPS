using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieZones : MonoBehaviour
{
    public static event Action<Transform> OnEnterZone;

    public AudioSource zoneSound;
    public AudioSource OnZoneEnterSound;
    GameObject Sheps;
    bool InZone;
    private void Start()
    {
        Sheps = GameObject.FindGameObjectWithTag("Sheps");
        zoneSound.Play();
    }


    private void Update()
    {
        float distance = (Sheps.transform.position - transform.position).magnitude;
        zoneSound.volume = 4 / (distance);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sheps")
        {            
            OnEnterZone(other.transform);
            if (!InZone)
            {
                OnZoneEnterSound.Play();
                InZone = true;
            }
        }
    }
}
