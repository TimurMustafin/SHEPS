using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public AudioSource[] audioSource;

    void Start()
	{
		
		foreach (AudioSource sound in audioSource)
		{
			sound.Play();
		}
	}


    void Update()
    {
        
    }
}
