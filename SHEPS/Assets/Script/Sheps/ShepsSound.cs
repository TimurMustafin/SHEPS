using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsSound : MonoBehaviour
{
    #region sounds
    public AudioSource ShepsStepsSound;
    public AudioSource ShepsScreaming;
    public AudioSource ShepsRun;
    public AudioSource ShepsFall;
    #endregion

    #region private fields
    private Animator shepsAnimator;
    private ShepsMotion shepsMotion;
    private IUserInput userInput;

    private bool isSteping;
    private bool isRuning;    
    private bool isScreaming;
    #endregion



    private void Start()
    {
        shepsAnimator = GetComponent<Animator>();
        shepsMotion = GetComponent<ShepsMotion>();
        userInput = GetComponent<IUserInput>();

        userInput.OnRunToggle += (bool Toggle) =>
        {
            if (!isRuning && Toggle)
            {
                isRuning = true;
                ShepsRun.Play();
            }
            else
            {
                ShepsRun.Stop();
            }
        };
    }

    private void Update()
    {
        if (shepsMotion.IsAttacked && !isScreaming)
        {
            ShepsScreaming.Play();
            isScreaming = true;
            return;
        }
        if (shepsMotion.IsAttacked) return;

        if (shepsMotion.IsFalling)
        {
            ShepsStepsSound.Stop();
            if (!isScreaming)
            {
                ShepsFall.Play();
                isScreaming = true;
            }                        
            return;
        }

        Steps();

                                    
    }

    void Steps()
    {
        if (shepsAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion") && !isSteping)
        {            
            ShepsStepsSound.Play();
            isSteping = true;
            isRuning = false;
        }
        else if(!shepsAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion") && isSteping)
        {
            ShepsStepsSound.Stop();
            isSteping = false;
        }
        
    }

}
