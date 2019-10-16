using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShepsSoundBomb : MonoBehaviour
{

    public static event Action OnSoundExplosion;
    public static float DamageZoneRadius = 30;
    public AudioSource ExplosionSound;
    public GameObject ExplosionEffect;
    public int counter = 1;
    IUserInput userInput;

    void Start()
    {
        userInput = GetComponent<IUserInput>();

        userInput.OnSoundBombToggle += () => {
            if (counter > 0)
            {
                SoundExplosion();
                counter--;
            }
        };
    }
    
    void Update()
    {
        
    }

    private void SoundExplosion()
    {
        ExplosionSound.Play();
        GameObject effect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        OnSoundExplosion();
    }
}
