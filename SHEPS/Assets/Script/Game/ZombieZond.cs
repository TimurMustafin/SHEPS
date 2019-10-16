using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieZond : MonoBehaviour
{
    AudioSource zombieSound;

    void Start()
    {
        zombieSound = GetComponent<AudioSource>();    
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sheps")
            zombieSound.Play();
    }
}
