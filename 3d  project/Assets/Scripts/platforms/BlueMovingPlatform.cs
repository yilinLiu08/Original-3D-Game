using System.Collections;
using UnityEngine;

public class BlueMovingPlatform : MonoBehaviour
{
    public float MovingSpeed = 270f;
    public float MovingAmount = 20f;
    public GameObject platform;

    private Vector3 originalPosition;
    private Transform playerTransform = null;
    private Vector3 playerPlatformOffset;
    private bool isPlayerOnPlatform = false;

    void Start()
    {
        originalPosition = platform.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueBall")
        {
            StartCoroutine(MovePlatform());
        }

        if (collision.gameObject.tag == "Player")
        {
            playerTransform = collision.transform;
            
            playerPlatformOffset = playerTransform.position - platform.transform.position;
            isPlayerOnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerOnPlatform = false;
        }
    }

    void Update()
    {
        if (isPlayerOnPlatform && playerTransform != null)
        {
            
            playerTransform.position = platform.transform.position + playerPlatformOffset;
        }
    }

    IEnumerator MovePlatform()
    {
        Vector3 targetPosition = new Vector3(platform.transform.position.x, platform.transform.position.y + MovingAmount, platform.transform.position.z);
        Vector3 startPosition = platform.transform.position;
        float distanceToMove = Vector3.Distance(startPosition, targetPosition);

        while (Vector3.Distance(platform.transform.position, targetPosition) > 0.01f)
        {
            float step = MovingSpeed * Time.deltaTime;
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, step);
            yield return null;
        }

        yield return new WaitForSeconds(5);

        while (Vector3.Distance(platform.transform.position, originalPosition) > 0.01f)
        {
            float step = MovingSpeed * Time.deltaTime;
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, originalPosition, step);
            yield return null;
        }
    }
}
