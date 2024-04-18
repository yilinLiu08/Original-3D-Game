using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewVoidEvent", menuName = "Events/VoidEvent")]
public class VoidEventSO : ScriptableObject
{
   
    public event Action OnEventRaised;

    
    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}
