using UnityEngine;
using UnityEngine.UI;

public class ShowMiniBossBlood : MonoBehaviour
{
    public GameObject uiElement;
    public AudioSource backgroundmusic;
    public AudioSource MainScene;

    void Start()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(false); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            uiElement.SetActive(true);
            backgroundmusic.Play(); 
            MainScene.Stop();

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            uiElement.SetActive(false);
            backgroundmusic.Stop();
            MainScene.Play();
        }
    }
}
