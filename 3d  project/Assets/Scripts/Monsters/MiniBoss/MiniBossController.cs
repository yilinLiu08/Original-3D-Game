using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniBossController : MonoBehaviour
{
    private int stunMeter = 5;
    public int maxStunHealth = 5;
    public int trueHealth = 3;

    public float unstunTimer = 8f;
    public float rainStopTimer = 15f;

    Animator animator;
    Transform player;
    NavMeshAgent meshAgent;

    public float attackTime;

    public float basicAttackDistance = 3.5f;
    public float chaseRange = 20f;

    public static event Action onStun;
    public GameObject rainController;
    public MiniBossAttack miniBossAttack;

    BossStates bossStates;

    enum BossStates
    {
        dieState,
        stunState,
        attackState,
        rainAttackState,
    }

    // Start is called before the first frame update
    void Start()
    {
        rainController.SetActive(false);
        stunMeter = maxStunHealth;
        meshAgent = GetComponent<NavMeshAgent>();
        meshAgent.speed = 50f;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossStates = BossStates.attackState;
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if(clip.name == "Zombie Attack")
            {
                attackTime = clip.length;
            }
        }
        if(attackTime <= 0f)
        {
            Debug.LogWarning("Atttack clip not found. Setting attack time to default value.");
            attackTime = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region "Switch States"
        switch (bossStates)
        {
            case BossStates.stunState:
                break;
            case BossStates.attackState:
                float distance = Vector3.Distance(player.position, transform.position);
                if (distance < chaseRange) //movement towards player
                {
                    animator.SetBool("isAttack1", false);
                    animator.SetBool("isMoving", true);
                    meshAgent.SetDestination(player.position);
                }
                if (distance < basicAttackDistance) //basic attack near player
                {
                    animator.transform.LookAt(player);
                    animator.SetBool("isAttack1", true);
                    miniBossAttack.Attack(attackTime);
                }
                break;
            case BossStates.rainAttackState:
                break;
            case BossStates.dieState:
                break;
            default:
                break;
        }
        #endregion
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueBall")
        {
            TakeDamage(1);
        }

        if (collision.gameObject.tag == "PurpleBall")
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (bossStates == BossStates.stunState || bossStates == BossStates.rainAttackState)
            return;
        stunMeter -= damage;
        Debug.Log("stun damage");
        if (stunMeter <= 0)
        {
            ChangeState(BossStates.stunState);
        }
    }

    public void DamageTrueHealth(int damage)
    {
        trueHealth -= damage;
        ChangeState(BossStates.attackState);
        Debug.Log("trueDamage");
        if (trueHealth <= 0)
        {
            ChangeState(BossStates.dieState);
        }
    }

    private void ChangeState(BossStates newState)
    {
        Debug.Log("StateCalled");
        bossStates = newState;
        StopCoroutine(UnstunTimer());
        miniBossAttack.StopAttackEarly();
        switch(newState)
        {
            case BossStates.stunState:
                animator.SetBool("isMoving", false);
                animator.SetTrigger("stun");
                meshAgent.isStopped = true;
                StartCoroutine(UnstunTimer());
                onStun();
                break;
            case BossStates.attackState:
                meshAgent.isStopped = false;
                stunMeter = maxStunHealth;
                animator.SetBool("isMoving", true);
                //animator.SetBool("isAttack1", true);
                break;
            case BossStates.rainAttackState:
                meshAgent.isStopped= true;
                animator.SetBool("isMoving", false);
                animator.SetTrigger("rainAttack");
                rainController.SetActive(true);
                StartCoroutine(RainStopTimer());
                break;
            case BossStates.dieState:
                animator.SetTrigger("die");
                meshAgent.isStopped = true;
                break;
            default:
                break;
        }
    }

    IEnumerator UnstunTimer()
    {
       yield return new WaitForSeconds(unstunTimer);
        ChangeState(BossStates.rainAttackState);
    }

    IEnumerator RainStopTimer()
    {
        yield return new WaitForSeconds(rainStopTimer);
        rainController.SetActive(false);
        ChangeState(BossStates.attackState);
    }
}
