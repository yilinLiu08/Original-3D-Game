using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public AudioSource openDoor;
    private Animator rubyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueBall" )
        {
            openDoor.Play();
            rubyAnimator.SetTrigger("OpenDoor");
            Destroy(gameObject,2f);
        }
    }
}
