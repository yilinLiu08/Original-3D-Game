using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster1Controller : MonoBehaviour
{   
    [Header("Health and Attack")]
    public int maxHealth = 50;
    public int health;
    public int damage;
    [SerializeField] FirstPersonController playerHealth;

    Rigidbody rb;
    Animator animator;
    NavMeshAgent meshAgent;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }

        if (collision.gameObject.tag == "BlueBall")
        {
            TakeDamage(10);
        }

        if (collision.gameObject.tag == "PurpleBall")
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            animator.SetTrigger("die");
            Destroy(gameObject, 3f);
        }
    }
}
