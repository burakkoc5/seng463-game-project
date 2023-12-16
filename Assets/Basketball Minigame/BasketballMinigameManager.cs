using System.Collections;
using TMPro;
using UnityEngine;

public class BasketballMinigameManager : MonoBehaviour
{
    [SerializeField] private Rigidbody basketballRigidbody;
    [SerializeField] private GameObject basketballPrefab;
    [SerializeField] private GameObject stick;
    [SerializeField] private GameObject closeUpCamera;
    [SerializeField] public TextMeshProUGUI scoredBasketsTMPUGUI;
    public bool gameOver = false; //false = ongoing, true = won/lost
    public int score = 0;
    
    IEnumerator InstantiateNewBall()
    {
        yield return new WaitForSeconds(2.5f);
        GameObject instantiatedBasketball = Instantiate(basketballPrefab);
        basketballRigidbody = instantiatedBasketball.GetComponent<Rigidbody>();
        stick.GetComponent<Stick>().enabled = true;
        stick.GetComponent<Floater>().enabled = true;
        closeUpCamera.SetActive(false);
    }
    
    public void throwBall(float x, float y, float z)
    {
        //TODO: Randomize X
        basketballRigidbody.AddForce(new Vector3(x, y, z), ForceMode.Impulse);
        closeUpCamera.SetActive(true);
        StartCoroutine(InstantiateNewBall());
    }
}
