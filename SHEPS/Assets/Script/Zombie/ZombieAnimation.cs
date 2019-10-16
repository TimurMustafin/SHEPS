using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAnimation : MonoBehaviour
{

    Animator zombieAnimator;
    ZombieMotion zombieMotion;
    


    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
        zombieMotion = GetComponent<ZombieMotion>();
    }

   
    void Update()
    {
        if (zombieMotion.currentTarget)
        {
            if (System.Math.Abs(zombieMotion.agent.velocity.magnitude) > 0.01)
            {
                zombieAnimator.SetFloat("Speed", 1f);
            }
            else
            {
                zombieAnimator.SetFloat("Speed", 0f);
            }

            if (zombieMotion.IsRunning)
            {
                zombieAnimator.SetBool("Run", zombieMotion.IsRunning);
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Sheps")
        {
            
            zombieAnimator.SetBool("Attack", zombieMotion.IsAttack);
        }
    }
}
