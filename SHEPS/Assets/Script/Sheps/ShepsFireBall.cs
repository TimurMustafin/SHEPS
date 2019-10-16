using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsFireBall : MonoBehaviour
{
    #region public fields
    public GameObject FireBallPrefab;
    public float delay;
    public Transform firePoint;
    public ShepsSetting shepsSetting;
    public AudioSource FireballSound;
    public float FireRate;
    #endregion

    #region private fields
    float timer;    
    int fireballCounter;
    IUserInput userInput;

    Vector3 startDirection;
    #endregion

    private void Start()
    {
        fireballCounter = shepsSetting.FireballAmount;
        userInput = GetComponent<IUserInput>();

        userInput.OnFireToggle += () => { StartCoroutine(FireBall()); };
    }

    public void Fire()
    {       
        StartCoroutine(FireBall());        
    }

    IEnumerator FireBall()
    {
        if (fireballCounter > 0)
        {
            fireballCounter--;

            /*timer = delay;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                yield return null;
            }*/

            GameObject currentFireBall = Instantiate(FireBallPrefab, firePoint.position, Quaternion.identity);
            startDirection = transform.forward;
            FireballSound.Play();

            timer = shepsSetting.FireballLifetime;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                currentFireBall.transform.position += startDirection * shepsSetting.FireballSpeed * Time.deltaTime;
                yield return null;
            }

            Destroy(currentFireBall);
        }
    }
}
