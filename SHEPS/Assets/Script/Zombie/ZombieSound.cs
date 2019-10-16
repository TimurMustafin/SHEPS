using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{

    #region Sounds
    public AudioSource Attack;
    public AudioSource Run;
    public AudioSource IsDiyng;
    #endregion

    ZombieMotion zombieMotion;
    bool isAttack;
    bool isRunning;

    void Start()
    {
        Attack = GetComponent<AudioSource>();
        Run = GetComponent<AudioSource>();
        zombieMotion = GetComponent<ZombieMotion>();
    }

    
    void Update()
    {
        if (zombieMotion.IsDying)
        {
            IsDiyng.Play();
            return;
        }
        if (zombieMotion.IsRunning && ! isRunning)
        {
            isRunning = true;
            Run.Play();
        }
        if (zombieMotion.IsAttack && !isAttack)
        {
            Run.Stop();
            isAttack = true;
            Attack.Play();
        }
        
            
    }
}
