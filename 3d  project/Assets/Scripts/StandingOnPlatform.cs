using UnityEngine;

public class StandingOnPlatform : MonoBehaviour
{
    public GameObject Player;
    public GameObject Platform;

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            
            Player.transform.parent = Platform.transform;
        }
    }
}
