using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoving : MonoBehaviour
{
    public GameObject[] statues; 
    public float[] intentions; 
    public GameObject door; 
    private bool doorShouldMove = false; 
    private Vector3 targetPosition = new Vector3(0.81f, 3.52f, 2.6f); 
    public float moveSpeed = 1f; 

   
    void Start()
    {
        if (statues.Length != intentions.Length)
        {
            
            return;
        }
    }

    
    void Update()
    {
        doorShouldMove = true; 
        for (int i = 0; i < statues.Length; i++)
        {
            if (!CheckAndMoveObject(statues[i], intentions[i]))
            {
                doorShouldMove = false; 
                break; 
            }
        }

        if (doorShouldMove)
        {
            print("open the door");
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    bool CheckAndMoveObject(GameObject statue, float intention)
    {
        if (statue == null)
        {
            return false; 
        }

        
        return Mathf.Approximately(statue.transform.eulerAngles.y, intention);
    }

}
