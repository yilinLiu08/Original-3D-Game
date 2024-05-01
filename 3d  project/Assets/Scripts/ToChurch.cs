using UnityEngine;

public class ToChurch : MonoBehaviour
{
    public Transform teleportTarget;
    public Transform playerTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            playerTransform.position = teleportTarget.position;
            print("yes");

        }
    }
}
