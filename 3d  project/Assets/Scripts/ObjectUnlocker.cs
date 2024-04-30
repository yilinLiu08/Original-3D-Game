using UnityEngine;

public class ObjectUnlocker : MonoBehaviour
{
    
    public ThrowingTutorial throwingTutorial;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
           
            for (int i = 0; i < throwingTutorial.unlockedObjects.Length; i++)
            {
                if (!throwingTutorial.unlockedObjects[i])
                {
                    throwingTutorial.UnlockObject(i);
                    Destroy(gameObject);
                    
                    break;  
                }
            }
        }
    }
}
