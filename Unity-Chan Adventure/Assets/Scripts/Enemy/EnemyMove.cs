using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform[] positionsToPatrol;
    int index = 0;
    public float speed = 4f;
    NavMeshAgent agent;
    private Animator animator;
    
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.speed = speed;
	}

    private void FixedUpdate()
    {
        EnemyWeakPoint enemyWeakPointTouched = FindObjectOfType<EnemyWeakPoint>();
        if(positionsToPatrol.Length > 0 && enemyWeakPointTouched.weakPointTouched == false)
        {
            float distanceToThePoint = Vector3.Distance(transform.position, positionsToPatrol[index].position);
            transform.LookAt(positionsToPatrol[index].position);
            //print("Distancia" + distanceToThePoint);
            if(distanceToThePoint > agent.stoppingDistance)
            {
                animator.SetBool("Moving", true);
                //print("Distancia" + distanceToThePoint);
                agent.destination = positionsToPatrol[index].position;
            }
            else if(index < positionsToPatrol.Length -1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }
}
