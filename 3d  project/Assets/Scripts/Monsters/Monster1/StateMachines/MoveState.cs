using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : StateMachineBehaviour
{
    float timer;
    float chaseRange = 8;
    Transform playerPosition;
    NavMeshAgent meshAgent;

    List<Transform> wayPoints = new List<Transform>();
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        meshAgent = animator.GetComponent<NavMeshAgent>();
        meshAgent.speed = 1.5f;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject go = GameObject.FindGameObjectWithTag("MonsterWaypoint");

        foreach (Transform t in go.transform)
        {
            wayPoints.Add(t);
        }

        meshAgent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (meshAgent.remainingDistance <= meshAgent.stoppingDistance)
        {
            meshAgent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("isMoving", false);
        float distance = Vector3.Distance(playerPosition.position, animator.transform.position);
        if (distance < chaseRange)
            animator.SetBool("isChasing", true);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        meshAgent.SetDestination(meshAgent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
