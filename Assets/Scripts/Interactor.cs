using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            Debug.DrawRay(InteractorSource.position, InteractorSource.forward, Color.green);
            
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                //Print all gameobjects that are hit by the raycast
                //Debug.Log(hitInfo.collider.gameObject.name);
                
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}