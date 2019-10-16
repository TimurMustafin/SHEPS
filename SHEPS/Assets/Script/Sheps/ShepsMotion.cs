using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsMotion : MonoBehaviour
{
    public static event Action OnShepsDying;
    public GameMaster gameMaster;
    [HideInInspector]
    public bool IsAttacked;
    [HideInInspector]
    public bool IsFalling;

    [SerializeField]
    private ShepsSetting shepsSetting;

    private IUserInput userInput;
    private float MovingSpeed;
    private float TurnigSpeed;
    


    private void Start()
    {
        MovingSpeed = shepsSetting.MovingSpeed;
        TurnigSpeed = shepsSetting.TurnigSpeed;
        
        userInput = GetComponent<IUserInput>();

        userInput.OnRunToggle += (bool Toggle) =>
        {                       
            if (Toggle)
            {
                MovingSpeed = 3 * shepsSetting.MovingSpeed;
            }
            else
            {
                MovingSpeed = shepsSetting.MovingSpeed;
            }                        
        };
        
    }

    private void Update()
    {
        if (IsAttacked)
            return;
        userInput.ReadInput();
        Move();
    }

    private void Move()
    {
        if(IsFalling)
        {
            transform.position += Vector3.down * 10 * Time.deltaTime + Vector3.forward * 3 * Time.deltaTime;            
            return;            
        }
            
       
        transform.position += transform.forward * userInput.Moving * MovingSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * userInput.Turning * TurnigSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Zombie")
        {
            if (!IsAttacked)
            {
                IsAttacked = true;
                Debug.Log("Event: Shep is Dying");
                OnShepsDying();
            }                      
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EmptyGrave")
        {        
            Invoke("Fall", 0.4f);
            
        }
    }

    private void Fall()
    {

        IsFalling = true;
        GetComponent<Rigidbody>().AddForce(transform.forward * 3 + transform.up, ForceMode.Impulse);
        gameMaster.GameIsOver();
        
    }
}
