using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class QuizMinigameManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject loseText;
    [SerializeField] Timer timerScript;
    private string winningCode = "GBRBGBBRBBRBRGRBBRBRBBGRBG";
    public bool playerWin;
    public bool submitButtonClicked;
    [SerializeField] GameObject resultPanel;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI gainInfoText;
    [SerializeField] private TextMeshProUGUI quizTypeInfoText;

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
                resultText.text = "You Win!";
                resultText.color = Color.green;
                infoText.text = "You have passed the quiz.";
                resultPanel.SetActive(true);
                switch (quizTypeInfoText.text)
                {
                    case "1":
                        gainInfoText.text = "You have gained 40 academy point.";
                        Singleton.increaseCurrentAcademy(40);
                        Debug.Log("Added 40 to academy point.");
                        break;
                    case "2":
                        gainInfoText.text = "You have gained 50 academy point.";
                        Singleton.increaseCurrentAcademy(50);
                        Debug.Log("Added 50 to academy point.");
                        break;
                }
            }
            else
            {
                timerScript.stopTimer = true;
                playerWin = false;
                resultText.text = "You Lost!";
                resultText.color = Color.red;
                infoText.text = "You could not pass the quiz.";
                gainInfoText.text = "You could not gain any academy point.";
                resultPanel.SetActive(true);
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
        //Set winning code based on the quiz type info text
        if (quizTypeInfoText.text.Contains("1"))
        {
            winningCode = "GBRBGBBRBBRBRGRBBRBRBBGRBG";
        }
        else if (quizTypeInfoText.text.Contains("2"))
        {
            winningCode = "BGRRGRRBRBBGRBGRBRGBGBRG";
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