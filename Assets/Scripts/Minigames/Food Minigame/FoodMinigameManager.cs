using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minigame_Related.Food_Minigame
{
    public class FoodMinigameManager : MonoBehaviour
    {
        [SerializeField] private FoodThrower[] fruitThrowerInstances;
        [SerializeField] public TextMeshProUGUI eatenHealthyFruitsTMPUGUI;
        [SerializeField] public TextMeshProUGUI eatenUnhealthyFruitsTMPUGUI;
        [SerializeField] private GameObject resultPanel;
        [SerializeField] private TextMeshProUGUI scorePercentageTMPUGUI;
        [SerializeField] private TextMeshProUGUI basicNeedGainInfoTMPUGUI;
    
        [HideInInspector]
        public int eatenHealthyFruits = 0, eatenUnhealthyFruits = 0;
        private bool gameCondition = true; //false = lost, true = won/ongoing

        private void Start()
        {
            eatenHealthyFruitsTMPUGUI.text = eatenHealthyFruits.ToString();
            eatenUnhealthyFruitsTMPUGUI.text = eatenUnhealthyFruits.ToString();
        }

        void Update()
        {
            if (eatenUnhealthyFruits >= 3 && gameCondition)
            {
                gameCondition = false;
                foreach (var fruitThrowerInstance in fruitThrowerInstances)
                {
                    fruitThrowerInstance.stop = true;
                }
                Invoke(nameof(DisplayResults), 2f);
            }
        }

        private void DisplayResults()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            int percentage = (int) ((double)eatenHealthyFruits / (eatenHealthyFruits+eatenUnhealthyFruits) * 100);
            scorePercentageTMPUGUI.text = percentage + "%";
            basicNeedGainInfoTMPUGUI.text = "You have gained " +  (percentage * 40) / 100 + " basic need point.";
            Singleton.increaseCurrentBasicNeed(percentage * 40);
            resultPanel.SetActive(true);
        }

        public void loadUniversityScene()
        {
            Cursor.visible = false;
            SceneManager.LoadScene("University");
        }
    }
}