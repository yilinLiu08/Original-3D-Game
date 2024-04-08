using UnityEngine;

public class ChurchBoss : MonoBehaviour
{
    public GameObject[] gameObjects; 
    public Material blueMaterial; 
    public Material purpleMaterial; 

    void Start()
    {
        
        InvokeRepeating("ChangeColors", 0, 10f);
    }

    void ChangeColors()
    {
        
        int uniqueIndex = Random.Range(0, gameObjects.Length);

       
        Material commonMaterial = (Random.Range(0, 2) == 0) ? blueMaterial : purpleMaterial;

        
        Material uniqueMaterial = commonMaterial == blueMaterial ? purpleMaterial : blueMaterial;

        for (int i = 0; i < gameObjects.Length; i++)
        {
            
            if (i == uniqueIndex)
            {
                gameObjects[i].GetComponent<Renderer>().material = uniqueMaterial;
            }
            else 
            {
                gameObjects[i].GetComponent<Renderer>().material = commonMaterial;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Triggered" );
        GameObject collider = other.gameObject;

        
        if (collider.tag == "BlueBall" || collider.tag == "PurpleBall")
        {
            print("yes");
            
            Material desiredMaterial = collider.tag == "BlueBall" ? blueMaterial : purpleMaterial;

            foreach (var obj in gameObjects)
            {
                
                if (obj.GetComponent<Renderer>().material != desiredMaterial)
                {
                    obj.GetComponent<Renderer>().material = desiredMaterial;
                    break; 
                }
            }
        }
    }
}
