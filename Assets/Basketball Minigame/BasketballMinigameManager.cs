using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketballMinigameManager : MonoBehaviour
{
    [SerializeField] private GameObject basketball;
    [SerializeField] private Rigidbody basketballRigidbody;
    [SerializeField] private float forceAmountX = 0f;
    [SerializeField] private float forceAmountY = 0f;
    [SerializeField] private float forceAmountZ = 0f;
    private float initialBasketballTransformX, initialBasketballTransformY, initialBasketballTransformZ;
    
    void Start()
    {
        var position = basketball.transform.position;
        initialBasketballTransformX = position.x;
        initialBasketballTransformY = position.y;
        initialBasketballTransformZ = position.z;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            basketballRigidbody.AddForce(new Vector3(forceAmountX, forceAmountY, forceAmountZ), ForceMode.Impulse);
            StartCoroutine(ResetBallPosition());
        }
    }
    
    IEnumerator ResetBallPosition()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
