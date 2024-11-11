using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Gives reference to the target. we are the target to the enemy
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;//Define the distance between the attacker and the player

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();//gives reference to NavMeshAgent
    }

    // Update is called once per frame
    void Update()
    {
        //compute distance between two game objects
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if(distanceToTarget > navMeshAgent.stoppingDistance)
        {
            GetComponent<Animator>().SetBool("attackParam", false);
            GetComponent<Animator>().SetTrigger("moveParam");
            navMeshAgent.SetDestination(target.position);
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            GetComponent<Animator>().SetBool("attackParam", true);
        }
        /*
        if(distanceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);

            //SetDestination tells it where to go. And we want it to go
            //to the target. Position tells where a certain game object is
            //Telling navMeshAgent to go find the player
        }*/
    }
}
