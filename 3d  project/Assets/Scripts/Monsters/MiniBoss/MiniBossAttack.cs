using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossAttack : MonoBehaviour
{
    public int damage;
    public Collider boxCollider;

    private IEnumerator coroutine;
    [SerializeField] FirstPersonController playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("HitPlayer");
            playerHealth.TakeDamage(damage);
        }
    }

    public void Attack(float attackTime)
    {
        boxCollider.enabled = true;
        coroutine = WaitForAttackEnd(attackTime);
        StartCoroutine(coroutine);
    }

    public void StopAttackEarly()
    {
        boxCollider.enabled = false;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator WaitForAttackEnd(float waitTime = 1f)
    {
        yield return new WaitForSeconds(waitTime);
        boxCollider.enabled = false;
    }
}
