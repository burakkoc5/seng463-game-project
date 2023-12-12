using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject interactionCrosshair;
    
    public void Interact()
    {
        crosshair.SetActive(false);
        interactionCrosshair.SetActive(true);
    }
}
