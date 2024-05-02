using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriggerUIStatue : MonoBehaviour
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
            textDisplay.text = "This statue is looking in a very specific direction";
            hasTriggered = true;
        }
    }
}
