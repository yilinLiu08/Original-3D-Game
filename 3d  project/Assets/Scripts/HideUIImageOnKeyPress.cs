using UnityEngine;

public class HideUIImageOnKeyPress : MonoBehaviour
{
    public GameObject uiImage; 

    void Update()
    {
        if (uiImage.activeSelf && Input.anyKeyDown) 
        {
            uiImage.SetActive(false); 
        }
    }
}
