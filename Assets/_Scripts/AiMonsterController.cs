using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMonsterController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody RB;

    public float MovementSpeed;
    public float AttackRadius;
    public GameObject target;
    public Animator Anim;

    public float AttackCooldown = .1f;
    public float SetAttackCooldown;

    void Start()
    {
        RB = GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = MovementSpeed;
        agent.acceleration = MovementSpeed * 2;
        agent.stoppingDistance = 0;
        agent.SetDestination(target.transform.position);
    }

    void Update()
    {
        updateAnim();

        SetAttackCooldown -= Time.deltaTime;

        float distanceBetween = agent.remainingDistance;

        if (agent.remainingDistance <= AttackRadius)
        {
            agent.isStopped = true;
            Debug.Log("STOP!");
            if (SetAttackCooldown <= 0)
            {
                Debug.Log("ATTACK!");
                Anim.SetTrigger("Attack");
            }
        }
        else if (SetAttackCooldown <= 0)
        {
            agent.isStopped = false;
            Debug.Log("WALK!");
        }
        if (target != null) //GameObject controller
        agent.SetDestination(target.transform.position);
    }    

    public void updateAnim()
    {
        Vector3 localVel = transform.InverseTransformDirection(agent.velocity);

        Anim.SetFloat("ForwardSpeed", localVel.z);
    }
}
