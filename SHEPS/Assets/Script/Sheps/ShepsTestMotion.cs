using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsTestMotion : MonoBehaviour
{
    Animator animator;
    public float Damp;
    public float Speed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float sum = v * v + h * h;
        animator.SetFloat("Speed", sum);
        Vector3 direction = Vector3.forward * v + Vector3.right * h;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Damp * Time.deltaTime);
        transform.Translate(direction * Speed * Time.deltaTime, Space.World);

    }
}
