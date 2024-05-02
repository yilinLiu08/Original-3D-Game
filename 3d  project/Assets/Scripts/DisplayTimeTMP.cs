using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DisplayTimeTMP : MonoBehaviour
{
    public TextMeshProUGUI timeText;  

    void Update()
    {
        
        DateTime now = DateTime.Now;
       
        timeText.text = now.ToString("HH:mm:ss");
    }
}
