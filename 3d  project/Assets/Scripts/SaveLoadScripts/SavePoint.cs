using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour, IInteractable
{
    public VoidEventSO saveDataEvent;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
           
            TriggerAction();
        }
    }

    public void TriggerAction()
    {
        saveDataEvent.RaiseEvent();
    }
}