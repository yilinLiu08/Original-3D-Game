using UnityEngine;
using System.Collections.Generic;

public class ChurchBoss : MonoBehaviour
{
    
    public MaterialChange[] objectsToChange;

    void Start()
    {
        
        StartCoroutine(ChangeMaterialsRandomly());
    }

    IEnumerator<WaitForSeconds> ChangeMaterialsRandomly()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(10);

            
            List<int> indexes = new List<int> { 0, 1, 2, 3 };
            int purpleIndex = Random.Range(0, indexes.Count);
            for (int i = 0; i < indexes.Count; i++)
            {
                if (i == purpleIndex)
                {
                    
                    objectsToChange[i].GetComponent<Renderer>().material = objectsToChange[i].PurpleMaterial;
                }
                else
                {
                    
                    objectsToChange[i].GetComponent<Renderer>().material = objectsToChange[i].BlueMaterial;
                }
            }
        }
    }
}
