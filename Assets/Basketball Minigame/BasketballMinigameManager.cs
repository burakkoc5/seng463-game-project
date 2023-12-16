using System.Collections;
using UnityEngine;

public class BasketballMinigameManager : MonoBehaviour
{
    [SerializeField] private Rigidbody basketballRigidbody;
    [SerializeField] private GameObject basketballPrefab;
    [SerializeField] private GameObject stick;
    
    IEnumerator InstantiateNewBall()
    {
        yield return new WaitForSeconds(2f);
        GameObject instantiatedBasketball = Instantiate(basketballPrefab);
        basketballRigidbody = instantiatedBasketball.GetComponent<Rigidbody>();
        stick.GetComponent<Stick>().enabled = true;
        stick.GetComponent<Floater>().enabled = true;
    }
    
    public void throwBall(float x, float y, float z)
    {
        //TODO: Randomize X
        basketballRigidbody.AddForce(new Vector3(x, y, z), ForceMode.Impulse);
        StartCoroutine(InstantiateNewBall());
    }
}
