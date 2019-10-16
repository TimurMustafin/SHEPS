using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class ZombieMotion : MonoBehaviour
{
    public event Action<Transform> OnNearZombie;


    [HideInInspector]
    public Transform currentTarget;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public float distanceFromCurrenTarget;
    [HideInInspector]
    public bool IsRunning;
    [HideInInspector]
    public bool IsAttack;
    [HideInInspector]
    public bool IsDying;



    public ZombieSettings ZombieSettings;
    public float InRange;
    public GameObject DyingEffect;

    GameObject Sheps;
    Vector3 startPosition;
    ZombieDying dying;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ZombieZones.OnEnterZone += (Transform target) => SetTarget(target);

        Sheps = GameObject.FindGameObjectWithTag("Sheps");
        startPosition = transform.position;

        AchivmentSystem.OnAchive += StopGame;
        OnNearZombie += (Transform target) => { SetTarget(target); };
        dying = GameObject.FindGameObjectWithTag("Dying").GetComponent<ZombieDying>();


        ShepsSoundBomb.OnSoundExplosion += () => {
            if (currentTarget)
            {
                Vector3 direction = transform.position - currentTarget.position;
                if(direction.magnitude < ShepsSoundBomb.DamageZoneRadius)
                StartCoroutine(OnSoundExplosion(direction));
            }
        };

    }

    private void Update()
    {
        if (currentTarget)
        {
            if (!agent.pathPending)
            {
                Move();
            }
        }
        else
        {
            if ((Sheps.transform.position - transform.position).magnitude < InRange)
            {
                SetTarget(Sheps.transform);
                OnNearZombie(Sheps.transform);
                Move();
            }
        }

    }

    void Move()
    {
        agent.SetDestination(currentTarget.position);

        distanceFromCurrenTarget = (currentTarget.position - transform.position).magnitude;

        if (distanceFromCurrenTarget < ZombieSettings.RangeIn)
        {
            IsRunning = true;
        }
        if (distanceFromCurrenTarget > ZombieSettings.RangeOut)
        {
            agent.velocity = Vector3.zero;
            IsRunning = false;
        }
    }

    void SetTarget(Transform target)
    {
        currentTarget = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Sheps")
        {
            IsAttack = true;

        }
        if (collision.collider.tag == "Fireball")
        {
            IsDying = true;
            GameObject dyingEffect = Instantiate(DyingEffect, transform.position, Quaternion.identity);
            dying.Dying();
            gameObject.SetActive(false);
            Destroy(dyingEffect, 2f);

        }
    }

    void StopGame()
    {
        if (agent)
        {
            agent.speed = 0;
            agent.velocity = Vector3.zero;
        }
        
    }

    IEnumerator OnSoundExplosion(Vector3 direction)
    {
        Time.timeScale = 0.2f;
        float timer = .3f;
        while (timer > 0)
        {
            transform.position += direction * 5 * Time.deltaTime;
            timer -= Time.deltaTime;
            yield return null;
        }
        Time.timeScale = 1f;
        agent.SetDestination(currentTarget.position);
    }
}
