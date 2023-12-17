using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        switch (gameObject.name)
        {
            case "QuizLoader1":
                SceneManager.LoadScene("Minigame v1");
                break;
            case "QuizLoader2":
                SceneManager.LoadScene("Minigame v2");
                break;
            case "FoodLoader":
                SceneManager.LoadScene("Food Minigame");
                break;
            case "SocializeLoader":
                SceneManager.LoadScene("Socialize Minigame");
                break;
            case "SocializeLoader2":
                SceneManager.LoadScene("Basketball");
                break;
        }
    }
}
