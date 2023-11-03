using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Sandbox : MonoBehaviour
{
    [SerializeField] private Button redButton;
    [SerializeField] private Button greenButton;
    [SerializeField] private Button blueButton;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject loseText;

    private void Start()
    {

        if (inputField != null)
        {
            // Attach the OnValueChanged event handler to validate and filter input
            inputField.onValueChanged.AddListener(ValidateAndFilterInput);
        }
    }

    private void ValidateAndFilterInput(string text)
    {
        // 'r', 'g', 'b', Enter, and Backspace
        string allowedChars = "rgbRGB\r\n\x08"; 
        string filteredText = new string(text.Where(c => allowedChars.Contains(c)).ToArray());
        inputField.text = filteredText.ToUpper();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (inputField.text == "RBRGG")
            {
                winText.SetActive(true);
            }
            else
            {
                loseText.SetActive(true);
            }

        //}
        //else if (Input.GetKeyDown(KeyCode.Backspace) && inputField.text != "") 
        //{
        //    inputField.text.Remove(inputField.text.Length - 1, 1);
        }



    }
    
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
