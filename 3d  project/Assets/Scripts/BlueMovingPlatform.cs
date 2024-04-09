using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMovingPlatform : MonoBehaviour
{
    public float MovingSpeed = 270f;
    public float MovingAmount = 20f; 
    public GameObject platform;

    private Vector3 originalPosition; 

    void Start()
    {
        
        originalPosition = platform.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "BlueBall")
        {
            
            StartCoroutine(MovePlatform());
        }
    }

    IEnumerator MovePlatform()
    {
        
        Vector3 targetPosition = new Vector3(platform.transform.position.x, platform.transform.position.y + MovingAmount, platform.transform.position.z);
        
        while (platform.transform.position != targetPosition)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, MovingSpeed * Time.deltaTime);
            yield return null;
        }

        
        yield return new WaitForSeconds(5);

        
        while (platform.transform.position != originalPosition)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, originalPosition, MovingSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
