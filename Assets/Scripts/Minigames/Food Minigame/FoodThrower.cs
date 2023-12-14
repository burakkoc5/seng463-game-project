using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace Minigame_Related.Food_Minigame
{
    public class FoodThrower : MonoBehaviour
    {
        [SerializeField] private bool reverseDirection = false;
        [SerializeField] private float minForceX = 1.5f;
        [SerializeField] private float maxForceX = 3.5f;
        [SerializeField] private float minForceY = 5f;
        [SerializeField] private float maxForceY = 8f;
        [SerializeField] private GameObject[] fruits;

        private Random _random = new Random();
        [HideInInspector]
        public bool stop = false;
    
        void Start()
        {
            if (reverseDirection)
            {
                minForceX *= -1;
                maxForceX *= -1;
            }
            StartCoroutine(ThrowFruit());
        }
    
        IEnumerator ThrowFruit()
        {
            if (!stop)
            {
                int randomFruitIndex = _random.Next(0, fruits.Length);
                
                GameObject currentFruit = Instantiate(fruits[randomFruitIndex], transform.position, Quaternion.identity);
                float randomForceX = (float) _random.NextDouble() * (maxForceX - minForceX) + minForceX;
                float randomForceY = (float) _random.NextDouble() * (maxForceY - minForceY) + minForceY;
                Vector3 forceAmount = new Vector3(randomForceX, randomForceY, 0);
                currentFruit.GetComponent<Rigidbody>().AddTorque(new Vector3(0,5,5), ForceMode.Impulse);
                currentFruit.GetComponent<Rigidbody>().AddForce(forceAmount, ForceMode.Impulse);
        
                float randomTimeBetweenFruits = _random.Next(1, 2);
                yield return new WaitForSeconds(randomTimeBetweenFruits);
        
                StartCoroutine(ThrowFruit());
            }
        }
    }
}