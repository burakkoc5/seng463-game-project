using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class SocializeMinigameManager : MonoBehaviour
{
    [SerializeField] private string[] questions;
    [SerializeField] private string[] answers;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private GameObject yesButton;
    [SerializeField] private GameObject noButton;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI scorePercentageTMPUGUI;
    [SerializeField] private TextMeshProUGUI socializeGainInfoTMPUGUI;
    
    private int correctAnswers;
    private int wrongAnswers;
    
    private string answer;
    private int currentQuestionIndex;
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        ShuffleArray(questions); //Shuffle the questions
        ShuffleArray(answers); //Shuffle the answers
        
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
            correctAnswers++;
            Debug.Log("Correct!");
        }
        else
        {
            wrongAnswers++;
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
            int percentage = (int) ((double)correctAnswers / (correctAnswers+wrongAnswers) * 100);
            scorePercentageTMPUGUI.text = percentage + "%";
            socializeGainInfoTMPUGUI.text = "You have gained " +  (percentage * 40) / 100 + " basic need point.";
            Singleton.currentSocial += percentage * 40;
            //TODO: Create a setter method for the currents in Singleton.cs and control the exceeding condition there
            if(Singleton.currentSocial >= 100) //To prevent exceeding 100
                Singleton.currentSocial = 100;
            resultPanel.SetActive(true);
            yesButton.GetComponent<Button>().interactable = false;
            noButton.GetComponent<Button>().interactable = false;
        }
    }
    
    public void loadUniversityScene()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("University");
    }
    
    static void ShuffleArray<T>(T[] array)
    {
        Random random = new Random();

        // Iterate through the array from the end to the beginning
        for (int i = array.Length - 1; i > 0; i--)
        {
            // Generate a random index within the array
            int randomIndex = random.Next(0, i + 1);

            // Swap the elements at the current and random indices
            (array[i], array[randomIndex]) = (array[randomIndex], array[i]);
        }
    }
    
}
