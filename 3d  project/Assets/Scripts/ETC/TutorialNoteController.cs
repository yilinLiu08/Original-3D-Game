using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TutorialNoteController : MonoBehaviour
{
    [SerializeField] private KeyCode closeKey;

    [SerializeField] private TutorialFirstPersonScript player;

    [Header("UI Text")]
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private GameObject playerCanvas;
    [SerializeField] private TMP_Text noteTextAreaUI;

    [SerializeField][TextArea] private string noteText;

    [SerializeField] private UnityEvent openEvent;
    private bool isOpen = false;

    public void ShowNote()
    {
        noteTextAreaUI.text = noteText;
        playerCanvas.SetActive(false);
        player.enabled = false;
        noteCanvas.SetActive(true);
        openEvent.Invoke();
        isOpen = true;
    }

    void DisableNote()
    {
        noteCanvas.SetActive(false);
        player.enabled = true;
        playerCanvas.SetActive(true);
        noteTextAreaUI.text = null;

        isOpen = false;
    }

    private void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(closeKey))
            {
                DisableNote();
            }
        }
    }
}
