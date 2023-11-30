using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Minigame_Related.Food_Minigame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private FruitThrower[] fruitThrowerInstances;
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
            int percentage = (int) ((double)eatenHealthyFruits / (eatenHealthyFruits+eatenUnhealthyFruits) * 100);;
            scorePercentageTMPUGUI.text = percentage + "%";
            //TODO: display basic need gain info
            resultPanel.SetActive(true);
        }
    }
}