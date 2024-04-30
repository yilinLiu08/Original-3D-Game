using UnityEngine;

public class ToChurch : MonoBehaviour
{
    public Transform teleportTarget; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.transform.position = teleportTarget.position;
        }
    }
}
