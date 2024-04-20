using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    [SerializeField] MovingPlatform movingPlatform;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(waitTime());
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBall") && gameObject.tag == "BluePlatform")
        {
            Debug.Log("Collision Detected");
            StartCoroutine(waitTime());
        }
        if (collision.gameObject.CompareTag("PurpleBall") && gameObject.tag == "PurplePlatform")
        {
            Debug.Log("Collision Detected");
            StartCoroutine(waitTime());
        }
        if (collision.gameObject.CompareTag("YellowBall") && gameObject.tag == "YellowPlatform")
        {
            Debug.Log("Collision Detected");
            StartCoroutine(waitTime());
        }
    }

    IEnumerator waitTime()
    {
        Debug.Log("Start Coroutine");
        movingPlatform.enabled = false;
        yield return new WaitForSeconds(4);

        Debug.Log("Finished Coroutine");
        movingPlatform.enabled = true;
    }
}
