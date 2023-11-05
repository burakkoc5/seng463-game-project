using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;


public class Sandbox : MonoBehaviour
{
    [SerializeField] private Button redButton;
    [SerializeField] private Button greenButton;
    [SerializeField] private Button blueButton;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject loseText;
    private string winningCode = "BBRBBRG";

    private void Start()
{
        if (inputField != null)
        {
            // Attach the OnValueChanged event handler to validate and filter input
            inputField.onValueChanged.AddListener(ValidateAndFilterInput);
            //Make sure the input field is selected when the scene starts
            inputField.Select();
            inputField.ActivateInputField();
        }
        string sceneName = SceneManager.GetActiveScene().name;

        //Set winning code based on scene name
        setWinCode(sceneName);
}

    private void ValidateAndFilterInput(string text)
    {
        // Only allow the characters 'R', 'G', 'B', '\r', '\n', and '\b' to be entered
        string allowedChars = "rgbRGB\r\n\x08"; 
        string filteredText = new string(text.Where(c => allowedChars.Contains(c)).ToArray());
        inputField.text = filteredText.ToUpper();
    }

    private void setWinCode(string sceneName)
    {
        //Set winning code based on the minigame version
        if (sceneName.Contains("v1"))
        {
            winningCode = "BBRBBRG";
        }
        else if (sceneName.Contains("v2"))
        {
            winningCode = "BGRRGRBB";
        }
    }

    void Update()
    {
        //Check if the player has entered the winning code
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (inputField.text == winningCode)
            {
                winText.SetActive(true);
            }
            else
            {
                loseText.SetActive(true);
            }

        }
    }
    //Button click handlers
    public void OnRedButtonClicked()
    {
        inputField.text += "R";
    }
    
    public void OnGreenButtonClicked()
    {
        inputField.text += "G";
    }
    
    public void OnBlueButtonClicked()
    {
        inputField.text += "B";
    }

}
