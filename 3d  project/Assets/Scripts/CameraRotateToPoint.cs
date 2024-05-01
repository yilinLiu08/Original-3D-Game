using System.Collections;
using UnityEngine;
using StarterAssets;

public class CameraRotateToPoint : MonoBehaviour
{
    public Transform targetPosition;
    public FirstPersonController playerController;

    private Vector3 startPosition;
    private Quaternion startRotation;

    public void ActivateCameraMovement()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;  // Save the initial rotation
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        playerController.enabled = false;

        float timeToMove = 2.0f;
        float elapsedTime = 0;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, (elapsedTime / timeToMove));
            // Interpolate rotation to face y=90 degrees
            Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, 90, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition.position;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 90, transform.eulerAngles.z); // Ensure it's exactly 90 degrees
        yield return new WaitForSeconds(5);

        elapsedTime = 0;
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(targetPosition.position, startPosition, (elapsedTime / timeToMove));
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.eulerAngles.x, 90, transform.eulerAngles.z), startRotation, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
        transform.rotation = startRotation; // Restore original rotation
        playerController.enabled = true;
    }
}
