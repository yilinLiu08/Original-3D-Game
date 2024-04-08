using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
    public Transform playerTransform; 
    public float height = 10.0f; 

    void LateUpdate()
    {
        
        if (playerTransform != null)
        {
            
            Vector3 playerPosition = playerTransform.position;

           
            transform.position = new Vector3(playerPosition.x, height, playerPosition.z);
        }
    }
}
