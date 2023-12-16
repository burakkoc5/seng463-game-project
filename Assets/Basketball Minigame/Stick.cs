using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] BasketballMinigameManager basketballMinigameManagerInstance;
    private Floater floaterInstance;
    private bool hitUpperRed, hitLowerRed, hitGreen;
    
    void Start()
    {
        floaterInstance = GetComponent<Floater>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // If the player presses the space key
        {
            if (hitGreen)
            {
                floaterInstance.enabled = false; // Disable the floater
                basketballMinigameManagerInstance.throwBall(0, 40f, 30f);
                this.enabled = false; // Disable this script
                Debug.Log("Success!");
            }
            else if (hitUpperRed)
            {
                floaterInstance.enabled = false; // Disable the floater
                basketballMinigameManagerInstance.throwBall(0, 55f, 30f);
                this.enabled = false; // Disable this script
                Debug.Log("Failure!");
            }
            else if (hitLowerRed)
            {
                floaterInstance.enabled = false; // Disable the floater
                basketballMinigameManagerInstance.throwBall(0, 20f, 30f);
                this.enabled = false; // Disable this script
                Debug.Log("Failure!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            case "Upper Red":
                hitUpperRed = true;
                break;
            case "Lower Red":
                hitLowerRed = true;
                break;
            case "Green":
                hitGreen = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.name)
        {
            case "Upper Red":
                hitUpperRed = false;
                break;
            case "Lower Red":
                hitLowerRed = false;
                break;
            case "Green":
                hitGreen = false;
                break;
        }
    }
}