using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriggerUI : MonoBehaviour
{
    public GameObject UIPanel;   
    public TMP_Text textDisplay; 
    private static bool hasTriggered = false; 

    void Start()
    {
        UIPanel.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && UIPanel.activeSelf)
        {
            UIPanel.SetActive(false); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (!hasTriggered && other.CompareTag("Player"))
        {
            UIPanel.SetActive(true);  
            textDisplay.text = "It seems that in this space, the elemental ball can have special functions."; 
            hasTriggered = true;      
        }
    }
}
