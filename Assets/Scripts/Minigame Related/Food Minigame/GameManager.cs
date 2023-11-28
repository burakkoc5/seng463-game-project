using TMPro;
using UnityEngine;

namespace Minigame_Related.Food_Minigame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private FruitThrower[] fruitThrowerInstances;
        [SerializeField] public TextMeshProUGUI eatenHealthyFruitsTMPUGUI;
        [SerializeField] public TextMeshProUGUI eatenUnhealthyFruitsTMPUGUI;
    
        public int eatenHealthyFruits = 0;
        public int eatenUnhealthyFruits = 0;
        private bool gameCondition = true; //false = lost, true = won/ongoing

        private void Start()
        {
            eatenHealthyFruitsTMPUGUI.text = eatenHealthyFruits.ToString();
            eatenUnhealthyFruitsTMPUGUI.text = eatenUnhealthyFruits.ToString();
        }

        void Update()
        {
            if (eatenUnhealthyFruits >= 3)
            {
                gameCondition = false;
                foreach (var fruitThrowerInstance in fruitThrowerInstances)
                {
                    fruitThrowerInstance.stop = true;
                }
            }
        }
    }
}