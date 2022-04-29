using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttack;

    //States
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;


    private void Awake() {

        player = GameObject.Find("Player").transform; 
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is in sight and in attack Range
        playerInSightRange = Physics.CheckSphere(transform.position,sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position,attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if(playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }

        
    }
    private void Patroling()
    {
            if(!walkPointSet)
            {
                SearchWalkPoint();
            }
            else if(walkPointSet)
            {
                    agent.SetDestination(walkPoint);
                    Vector3 distanceToWalkPoint = transform.position - walkPoint;

                //Walkpoint reached
                if(distanceToWalkPoint.magnitude < 1f)
                {
                    walkPointSet = false;
                }
            }
    }

    private void SearchWalkPoint()
    {
        //calculate RandomPoint in Range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX + transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast (walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }


    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }

    private void AttackPlayer()
    {
            //Make sure Enemy doesnt move
            agent.SetDestination(transform.position);
            transform.LookAt(player);
    }
}
