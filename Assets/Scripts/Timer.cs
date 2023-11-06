using TMPro;
using UnityEngine;

public class Timer: MonoBehaviour {

    [SerializeField] float targetTime = 60.0f;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject loseText;
    [SerializeField] Sandbox sandboxScript;
    public bool stopTimer;

    private void Start()
    {
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
        loseText.SetActive(true);
        stopTimer = true;
    }

}