using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsAnimation : MonoBehaviour
{
    public GameObject BloodEffect;

    IUserInput userInput;
    ShepsMotion shepsMotion;
    ShepsFireBall shepsFireBall;    

    Animator shepsAnimator;
    AnimatorStateInfo stateInfo;

    [HideInInspector]
    public bool IsCuttingSpace;
    
    void Start()
    {
        shepsAnimator = GetComponent<Animator>();

        userInput = GetComponent<IUserInput>();
        userInput.OnRunToggle += (bool Toggle) => shepsAnimator.SetBool("IsRunning", Toggle);
        userInput.OnFireToggle += () => {            
            StartCoroutine(CutSpace());            
        };

        shepsMotion = GetComponent<ShepsMotion>();
        shepsFireBall = GetComponent<ShepsFireBall>();
        stateInfo = shepsAnimator.GetCurrentAnimatorStateInfo(0);
        BloodEffect.SetActive(false);
        
    }
    
    void Update()
    {
        
        if (shepsMotion.IsAttacked)
        {
            Dying();
            return;
        }
        userInput.ReadInput();
        Move();        
       
    }

    void Move()
    {
        float Speed = Mathf.Abs(userInput.Moving) + Mathf.Abs(userInput.Turning);
        shepsAnimator.SetFloat("Speed", Speed);
    }

    void Dying()
    {
        shepsAnimator.SetBool("IsDying", shepsMotion.IsAttacked);
        BloodEffect.SetActive(true);
    }

    IEnumerator CutSpace()
    {
        shepsAnimator.SetBool("CutSpace", true);
        shepsFireBall.Fire();
        float timer = 1f;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        shepsAnimator.SetBool("CutSpace", false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EmptyGrave")
        {
            shepsAnimator.SetBool("IsFalling", true);
        }
    }


    
}
