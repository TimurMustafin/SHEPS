using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsMotion : MonoBehaviour
{
    public Transform phrases;
    public Animator animator;
    public DATA data;
    public AudioSource shepsSteps;
    AudioSource[] shepsPhrases;
    public Light lightSheps;
    float startLightIntensity;
    bool isPlaying;
    bool isSpeeking;
    bool isBegining;
    bool isStoped;
    int phraseCounter;
    int index;

    float speed;

    private void Start()
    {
        startLightIntensity = lightSheps.intensity;
        isPlaying = false;
        shepsPhrases = phrases.GetComponent<ShepsPhrases>().shepsPhrases;
        isSpeeking = false;
        isBegining = true;
        
    }


    void Update()
    {
        speed = data.speedPlayer;
        animator.SetFloat("Speed", Input.GetAxis("Vertical"));
        Debug.Log(Input.GetAxis("Vertical"));
        
        if (Input.GetAxis("Vertical") > 0f && !isPlaying)
        {
            isStoped = false;
            isSpeeking = false;
            Invoke("Steps", 0.5f);
            isPlaying = true;
            ResetPhrases();
            isBegining = false;
        }
        else if(Input.GetAxis("Vertical") <= 0f && !isStoped)
        {
            isStoped = true;
            StopMove();
        }

        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime, Space.World);

        lightSheps.intensity = startLightIntensity + UnityEngine.Random.value * 3;

        if (isSpeeking)
        {
            index = phraseCounter++ % shepsPhrases.Length;
            shepsPhrases[index].enabled = true;
            shepsPhrases[index].Play();
            isSpeeking = false;
        }
        
    }

    private void StopMove()
    {
        shepsSteps.Stop();
        isPlaying = false;
        if(!isBegining)
        isSpeeking = true;
       
    }

    void Steps()
    {
        shepsSteps.Play();
    }

    public void ResetPhrases()
    {
        foreach (var phrases in shepsPhrases)
        {
            phrases.enabled = false;
        }
    }

}
