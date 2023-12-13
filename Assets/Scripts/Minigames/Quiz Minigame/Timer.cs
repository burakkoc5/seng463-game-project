using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float targetTime = 60.0f;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject loseText;
    [SerializeField] Sandbox sandboxScript;
    [SerializeField] GameObject resultPanel;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI gainInfoText;

    public bool stopTimer;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        timerText.text = targetTime.ToString("0");
    }

    private void Update()
    {
        if (!stopTimer)
        {
            targetTime -= Time.deltaTime;
            timerText.text = targetTime.ToString("0");

            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }
    }

    void timerEnded()
    {
        timerText.text = "0";
        inputField.interactable = false;
        sandboxScript.playerWin = false;
        resultText.text = "You Lost!";
        resultText.color = Color.red;
        infoText.text = "You could not pass the quiz.";
        gainInfoText.text = "You could not gain any academy point.";
        resultPanel.SetActive(true);
        //No need for switch-case since the result of losing is the same in the both quiz mini-games
        
        stopTimer = true;
    }
    
    public void loadUniversityScene()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("University");
    }
}