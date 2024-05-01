using UnityEngine;

public class ObjectUnlocker : MonoBehaviour
{
    public GameObject ChurchDoor;
    public ThrowingTutorial throwingTutorial;
    public AudioSource trigger;

    private void OnTriggerEnter(Collider other)
        
    {
        
        if (other.CompareTag("Player"))
        {
           
            for (int i = 0; i < throwingTutorial.unlockedObjects.Length; i++)
            {
                if (!throwingTutorial.unlockedObjects[i])
                {
                    throwingTutorial.UnlockObject(i);
                    trigger.Play();
                    Destroy(gameObject);
                    Destroy(ChurchDoor);

                    break;  
                }
            }
        }
    }
}
