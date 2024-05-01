using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.2f;
    public float dampingSpeed = 1.0f;

    Vector3 initialPosition;

   
    bool isShakingEnabled = false;

    void Awake()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0 && isShakingEnabled)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
            isShakingEnabled = false; 
        }
    }

    public void TriggerShake()
    {
        if (isShakingEnabled)
        {
            shakeDuration = 3.0f; 
        }
    }

    
    public void EnableShaking()
    {
        isShakingEnabled = true;
    }
}
