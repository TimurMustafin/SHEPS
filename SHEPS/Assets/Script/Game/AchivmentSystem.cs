using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AchivmentSystem : MonoBehaviour
{
    public static event Action OnAchive;
    public string playerTag;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == playerTag)
        {
            Debug.Log("Event: Achivment System Collides!");
            OnAchive();
        }
                      
    }


}
