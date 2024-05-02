using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour, IInteractable
{
    public VoidEventSO saveDataEvent;
    public AudioSource audiotrigger;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            audiotrigger.Play();
            TriggerAction();
        }
    }

    public void TriggerAction()
    {
        saveDataEvent.RaiseEvent();
    }
}