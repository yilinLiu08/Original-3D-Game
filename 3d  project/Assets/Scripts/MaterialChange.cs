using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material BlueMaterial;
    public Material PurpleMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        
        Renderer renderer = GetComponent<Renderer>();

        
        if (collision.gameObject.tag == "BlueBall" && renderer != null && BlueMaterial != null)
        {
            renderer.material = BlueMaterial;
        }
        
        else if (collision.gameObject.tag == "PurpleBall" && renderer != null && PurpleMaterial != null)
        {
            renderer.material = PurpleMaterial;
        }
    }
}
