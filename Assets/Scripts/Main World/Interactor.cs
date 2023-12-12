using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    //private Transform interactorSource;
    private Transform cameraTransform;
    public float interactRange;
    
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject interactionCrosshair;

    private void Start()
    {
        if (Camera.main != null) 
            cameraTransform = Camera.main.transform;
        //interactorSource = GetComponent<Transform>();
    }

    void Update()
    {
        //Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        //Debug.DrawRay(InteractorSource.position, InteractorSource.forward, Color.green);

        Ray r = new Ray(cameraTransform.position, cameraTransform.forward);
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward, Color.green);

        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj) && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
            {
                interactObj.Interact();
            }
            
            if (hitInfo.collider.gameObject.CompareTag("Interactable"))
            {
                crosshair.SetActive(false);
                interactionCrosshair.SetActive(true);
            }
            else
            {
                crosshair.SetActive(true);
                interactionCrosshair.SetActive(false);
            }
        }
    }
}