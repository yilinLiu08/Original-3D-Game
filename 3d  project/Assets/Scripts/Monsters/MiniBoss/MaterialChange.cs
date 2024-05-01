using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material BlueMaterial;
    public Material PurpleMaterial;
    public Material DefaultMaterial;
    public AudioSource light;

    public bool isPurple;
    public bool canChange;

    private void OnCollisionEnter(Collision collision)
    {
        light.Play();
        if (!canChange)
            return;
        
        Renderer renderer = GetComponent<Renderer>();
        

        if (collision.gameObject.tag == "BlueBall" && renderer != null && BlueMaterial != null)
        {
            renderer.material = BlueMaterial;
            isPurple = false;
        }
        if (collision.gameObject.tag == "PurpleBall" && renderer != null && PurpleMaterial != null)
        {
            renderer.material = PurpleMaterial;
            isPurple = true;
        }
    }

    public void ResetOrb()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = DefaultMaterial;
        isPurple = false;
    }
}
