using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialMonster1Controller : MonoBehaviour
{
    [Header("Health and Attack")]
    public int maxHealth = 50;
    public int health;
    public int damage;
    [SerializeField] TutorialFirstPersonScript playerHealth;

    public AudioSource die;
    public AudioSource damageAudio;
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

    void Update()
    {

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
        damageAudio.Play();
        health -= damage;
        if (health <= 0)
        {
            animator.SetTrigger("die");
            die.Play();
            Destroy(gameObject, 3f);
        }
    }
}
