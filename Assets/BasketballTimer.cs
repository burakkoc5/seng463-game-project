using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BasketballTimer : MonoBehaviour
{
    [SerializeField] float targetTime = 60.0f;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoredBasketsTMPUGUI;
    [SerializeField] private TextMeshProUGUI socializeGainInfoTMPUGUI;
    [SerializeField] private BasketballMinigameManager basketballMinigameManagerInstance;
    [SerializeField] private GameObject resultPanel;
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        basketballMinigameManagerInstance.gameOver = true;
        timerText.text = "0";
        stopTimer = true;
        scoredBasketsTMPUGUI.text = basketballMinigameManagerInstance.score.ToString();
        socializeGainInfoTMPUGUI.text = "You have gained " + (basketballMinigameManagerInstance.score * 2) + " socialize point.";
        resultPanel.SetActive(true);
    }
    
    public void loadUniversityScene()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("University");
    }
}
