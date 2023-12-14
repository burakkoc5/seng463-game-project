using UnityEngine;
using UnityEngine.Serialization;

namespace Minigame_Related.Food_Minigame
{
    public class FoodCollector : MonoBehaviour
    {
        [FormerlySerializedAs("foodMinigameInstance")] [FormerlySerializedAs("gameManagerInstance")] [SerializeField] private FoodMinigameManager foodMinigameManagerInstance;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip eatSFX;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("HealthyFruit") )
            {
                Destroy(other.transform.gameObject);
                audioSource.PlayOneShot(eatSFX);
                foodMinigameManagerInstance.eatenHealthyFruits++;   
                foodMinigameManagerInstance.eatenHealthyFruitsTMPUGUI.text = foodMinigameManagerInstance.eatenHealthyFruits.ToString();
            }
            else if (other.CompareTag("UnhealthyFruit"))
            {
                Destroy(other.transform.gameObject);
                audioSource.PlayOneShot(eatSFX);
                if (foodMinigameManagerInstance.eatenUnhealthyFruits !< 3)
                {
                    foodMinigameManagerInstance.eatenUnhealthyFruits++;
                    foodMinigameManagerInstance.eatenUnhealthyFruitsTMPUGUI.text = foodMinigameManagerInstance.eatenUnhealthyFruits.ToString();
                }
            }
        }
    }
}
