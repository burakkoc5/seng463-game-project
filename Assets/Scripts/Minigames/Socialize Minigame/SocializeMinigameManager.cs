using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SocializeMinigameManager : MonoBehaviour
{
    [SerializeField] private string[] questions;
    [SerializeField] private string[] answers;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private GameObject yesButton;
    [SerializeField] private GameObject noButton;
    
    private string answer;
    private int currentQuestionIndex;
    
    void Start()
    {
        currentQuestionIndex = 0;
        questionText.text = questions[0];
    }
    
    public void YesButton()
    {
        answer ="yes";
        CheckAnswer();
    }
    
    public void NoButton()
    {
        answer = "no";
        CheckAnswer();
    }

    private void CheckAnswer()
    {
        if (answer == answers[currentQuestionIndex])
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        if (!(currentQuestionIndex + 1 >= questions.Length))
        {
            currentQuestionIndex++;
            questionText.text = questions[currentQuestionIndex];
        }
        else
        {
            Debug.Log("End of questions!");
            yesButton.GetComponent<Button>().interactable = false;
            noButton.GetComponent<Button>().interactable = false;
        }
    }
    
}
