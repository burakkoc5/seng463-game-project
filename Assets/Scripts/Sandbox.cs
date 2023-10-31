using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sandbox : MonoBehaviour
{
    [SerializeField] private Button redButton;
    [SerializeField] private Button greenButton;
    [SerializeField] private Button blueButton;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject winText;
    private TextMeshProUGUI winTextMesh;

    private void Start()
    {
        winTextMesh = winText.GetComponent<TextMeshProUGUI>();
        winTextMesh.text = "YOU LOST!";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (inputField.text == "BBRBBRG")
            {
                winText.SetActive(true);
            }
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
