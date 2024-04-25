using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDamage : MonoBehaviour
{
    public int damage;

    [SerializeField] FirstPersonController playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("HitPlayer");
            playerHealth.TakeDamage(damage);
        }
    }
}
