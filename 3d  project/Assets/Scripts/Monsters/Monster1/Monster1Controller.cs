using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Controller : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 20f;
    public float rotationSpeed = 100f;

    private bool isMoving = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    [Header("Health and Attack")]
    public int maxHealth = 50;
    public int health;
    public int damage;
    [SerializeField] FirstPersonController playerHealth;

    Rigidbody rb;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region "movement"
        if (isMoving == false)
        {
            StartCoroutine(Move());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up *Time.deltaTime * rotationSpeed);
        }
        if (isWalking == true)
        {
            rb.AddForce(transform.forward * movementSpeed);
            animator.SetBool("isMoving", true);
        }

        if (isMoving == false)
        {
            animator.SetBool("isMoving", false);
        }
        #endregion
    }

    IEnumerator Move()
    {
        #region"movement"
        int rotationTime = Random.Range(1, 2);
        int rotateWait = Random.Range(1, 2);
        int rotateDirection = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        isMoving = true;

        yield return new WaitForSeconds(walkWait);

        isWalking = true;

        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        yield return new WaitForSeconds(rotateWait);

        if (rotateDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }

        if (rotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isMoving = false;
        #endregion
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
            StopCoroutine(Move());
            animator.SetTrigger("die");
            Destroy(gameObject, 3f);
        }
    }
}
