using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class Sandbox : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject loseText;
    [SerializeField] Timer timerScript;
    private string winningCode = "BBRBBRG";
    public bool playerWin;
    public bool submitButtonClicked;

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

    void Update()
    {
        //Check if the player has entered the winning code
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || submitButtonClicked)
        {
            if (inputField.text == winningCode)
            {
                timerScript.stopTimer = true;
                playerWin = true;
                winText.SetActive(true);
            }
            else
            {
                timerScript.stopTimer = true;
                playerWin = false;
                loseText.SetActive(true);
            }
        }
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

    public void OnSubmitButtonClicked()
    {
        submitButtonClicked = true;
    }
}