using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockController : MonoBehaviour
{
    public SitController sitController;
    public Transform playerSpawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            sitController.canDock = true;
            sitController.playerRespawnPoint = playerSpawnPoint.position;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            sitController.canDock = false;
        }
    }
}
