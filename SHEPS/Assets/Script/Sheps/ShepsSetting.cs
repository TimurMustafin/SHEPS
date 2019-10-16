using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Sheps Settings")]
public class ShepsSetting : ScriptableObject
{
    [SerializeField]
    private float movingSpeed;
    [SerializeField]
    private float turnigSpeed;
    [SerializeField]
    private float fireballLifetime;
    [SerializeField]
    private float fireballSpeed;
    [SerializeField]
    private int fireballAmount;

    public float MovingSpeed { get => movingSpeed; }
    public float TurnigSpeed { get => turnigSpeed; }
    public float FireballLifetime { get => fireballLifetime; }
    public float FireballSpeed { get => fireballSpeed; }
    public int FireballAmount { get => fireballAmount; }
}
