using UnityEngine;
using Random = System.Random;

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
        //TODO: Refactor some lines into methods
        if (Input.GetKeyDown(KeyCode.Space) && !basketballMinigameManagerInstance.gameOver) // If the player presses the space key
        {
            Random random = new Random();
            if (hitGreen)
            {
                floaterInstance.enabled = false; // Disable the floater
                float randomX = NextFloat(-1.4f, -0.68f);
                int randomY = random.Next(37, 43);
                basketballMinigameManagerInstance.throwBall(randomX, randomY, 30f);
                Debug.Log("Force : " + randomX + " " + randomY + " " + 30f);
                this.enabled = false; // Disable this script
                basketballMinigameManagerInstance.scoredBasketsTMPUGUI.text = (++basketballMinigameManagerInstance.score).ToString();
                GetComponent<Floater>().frequency *= 1.2f; // Speed up the stick when the player scores
            }
            else if (hitUpperRed)
            {
                floaterInstance.enabled = false; // Disable the floater
                float randomX = NextFloat(-1.88f, -0.68f);
                int randomY = random.Next(45, 55);
                basketballMinigameManagerInstance.throwBall(randomX, randomY, 30f);
                Debug.Log("Force : " + randomX + " " + randomY + " " + 30f);
                this.enabled = false; // Disable this script
                GetComponent<Floater>().frequency /= 1.1f; // Slow down the stick when the player scores
            }
            else if (hitLowerRed)
            {
                floaterInstance.enabled = false; // Disable the floater
                float randomX = NextFloat(-1.88f, -0.68f);
                int randomY = random.Next(15, 25);
                basketballMinigameManagerInstance.throwBall(randomX, randomY, 30f);
                Debug.Log("Force : " + randomX + " " + randomY + " " + 30f);
                GetComponent<Floater>().frequency /= 1.1f; // Slow down the stick when the player scores
                this.enabled = false; // Disable this script
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
    
    static float NextFloat(float min, float max){
        Random random = new Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}