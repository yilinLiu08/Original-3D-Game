using System.Collections;
using UnityEngine;

public class RotationPurple : MonoBehaviour
{
    public float rotationSpeed = 270f;
    public float rotationAmount = 90f;
    public AudioSource RotationSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PurpleBall")
        {

            StartCoroutine(RotateOverTime(rotationAmount, rotationSpeed));
            RotationSound.Play();
        }
    }

    private IEnumerator RotateOverTime(float amount, float speed)
    {
        float remainingAngle = amount;
        while (remainingAngle > 0)
        {

            float rotationThisFrame = Mathf.Min(speed * Time.deltaTime, remainingAngle);

            transform.Rotate(0, rotationThisFrame, 0, Space.Self);

            remainingAngle -= rotationThisFrame;

            yield return null;
        }
    }
}