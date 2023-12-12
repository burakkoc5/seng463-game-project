using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    private Transform InteractorSource;
    public float InteractRange;
    [SerializeField] GameObject followCam;
    private Transform cameraTransform;

    private void Start()
    {
         cameraTransform = Camera.main.transform;
        InteractorSource =followCam.GetComponent<Transform>();
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E))
         {
             Debug.Log("Pressed E");
             
            //Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            //Debug.DrawRay(InteractorSource.position, InteractorSource.forward, Color.green);
            
            Ray r = new Ray(cameraTransform.position,cameraTransform.forward);
            Debug.DrawRay(cameraTransform.position,cameraTransform.forward, Color.green);
            
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                //Print all gameobjects that are hit by the raycast
                //Debug.Log(hitInfo.collider.gameObject.name);
                
                Debug.Log("Inside of second if statement");
                
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    Debug.Log("Inside of third if statement");
                    interactObj.Interact();
                }
            }
         }
    }
}