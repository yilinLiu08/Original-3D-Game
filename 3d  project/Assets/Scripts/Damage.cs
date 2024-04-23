using UnityEngine;
using StarterAssets;

public class Damage : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FirstPersonController playerHealth = collision.gameObject.GetComponent<FirstPersonController>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
