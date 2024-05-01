using UnityEngine;

public class PositionController : MonoBehaviour
{
    public Transform target;
    public float positionRange;
    public float sizeMultiplier;
    private Vector3 originalScale;
    private bool positionReached = false;
    private bool sizeReached = false;
    public bool sizeAndPositionReached = false;  
    public AudioSource trigger;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        CheckPosition();
        CheckScale();
        UpdateStatus();  
    }

    void CheckPosition()
    {
        if (Vector3.Distance(transform.position, target.position) <= positionRange)
        {
            if (!positionReached)
            {
                Debug.Log("position reached!");
                
                positionReached = true;
            }
        }
        else
        {
            if (positionReached)
            {
                Debug.Log("position left!");
                positionReached = false;
            }
        }
    }

    void CheckScale()
    {
        if (Mathf.Approximately(transform.localScale.x, originalScale.x * sizeMultiplier))
        {
            if (!sizeReached)
            {
                Debug.Log("size reached!");
                trigger.Play();

                sizeReached = true;
            }
        }
        else
        {
            if (sizeReached)
            {
                Debug.Log("size left!");
                sizeReached = false;
            }
        }
    }

    void UpdateStatus()
    {
        
        if (positionReached && sizeReached)
        {
            if (!sizeAndPositionReached) 
            {
                Debug.Log("Both size and position reached!");
                
                sizeAndPositionReached = true;
            }
        }
        else
        {
            if (sizeAndPositionReached)  
            {
                Debug.Log("Either size or position left, status not reached!");
                sizeAndPositionReached = false;
            }
        }
    }

    
}


