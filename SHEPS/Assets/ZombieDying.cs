using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDying : MonoBehaviour
{
    public AudioSource zombieDying;

    public void Dying()
    {
        zombieDying.Play();
    }
   
}
