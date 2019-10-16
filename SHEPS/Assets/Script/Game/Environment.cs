using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public AudioSource[] audioSource;
    public AudioSource WolfSound;

    void Start()
    {

        foreach (AudioSource sound in audioSource)
        {
            sound.Play();
        }

        AchivmentSystem.OnAchive += () => WolfSound.Play();
	}


    void Update()
    {
        
    }
}
