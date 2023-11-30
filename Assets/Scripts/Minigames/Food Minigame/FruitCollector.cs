using UnityEngine;

namespace Minigame_Related.Food_Minigame
{
    public class FruitCollector : MonoBehaviour
    {
        [SerializeField] private GameManager gameManagerInstance;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip eatSFX;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("HealthyFruit") )
            {
                Destroy(other.transform.gameObject);
                audioSource.PlayOneShot(eatSFX);
                gameManagerInstance.eatenHealthyFruits++;   
                gameManagerInstance.eatenHealthyFruitsTMPUGUI.text = gameManagerInstance.eatenHealthyFruits.ToString();
            }
            else if (other.CompareTag("UnhealthyFruit"))
            {
                Destroy(other.transform.gameObject);
                audioSource.PlayOneShot(eatSFX);
                if (gameManagerInstance.eatenUnhealthyFruits !< 3)
                {
                    gameManagerInstance.eatenUnhealthyFruits++;
                    gameManagerInstance.eatenUnhealthyFruitsTMPUGUI.text = gameManagerInstance.eatenUnhealthyFruits.ToString();
                }
            }
        }
    }
}
