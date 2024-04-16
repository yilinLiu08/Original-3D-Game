using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Vector3 initialScale;
    public Transform target;
    public float speed = 5f;
    private bool isRotating = true;

    void Update()
    {
        if (isRotating && target != null)
        {
            transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
        }
    }
    

    void Start()
    {
        initialScale = transform.localScale;
    }


    void OnTriggerEnter(Collider other)
    {
        print("Trigger");

        if (other.gameObject.CompareTag("YellowBall"))
        {
            print("Trigger yellow");
            isRotating = !isRotating;
        }
        else if (other.gameObject.CompareTag("BlueBall"))
        {
            Vector3 newScale = transform.localScale * 2; 
            if (newScale.x <= 2 * transform.parent.localScale.x) 
            {
                
                transform.localScale = newScale;
            }
        }
        else if (other.gameObject.CompareTag("PurpleBall"))
        {
            Vector3 newScale = transform.localScale * 0.5f;
            if (newScale.x >= 0.5f * initialScale.x) 
            {

                transform.localScale = newScale;
            }
        }

    }
}
