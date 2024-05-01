using UnityEngine;

public class PlanetsController : MonoBehaviour
{
    public PositionController[] controllers;
    public GameObject targetGameObject;
    public AudioSource trigger;

    private bool allPositionsAndSizesReached = false;

    public CameraRotateToPoint cameraScript;

    void Start()
    {
        cameraScript.enabled = false; 
    }

    void Update()
    {
        CheckAllPositionsAndSizes();
    }

    void CheckAllPositionsAndSizes()
    {
        foreach (PositionController controller in controllers)
        {
            if (!controller.sizeAndPositionReached)
            {
                if (allPositionsAndSizesReached)
                {
                    allPositionsAndSizesReached = false;
                    targetGameObject.SetActive(false);
                }
                return;
            }
        }

        if (!allPositionsAndSizesReached)
        {
            cameraScript.enabled = true; 
            cameraScript.ActivateCameraMovement();
            Debug.Log("All planets true!");
            trigger.Play();
            allPositionsAndSizesReached = true;
            targetGameObject.SetActive(true);
        }
    }
}
