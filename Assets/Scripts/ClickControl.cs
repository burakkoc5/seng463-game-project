using UnityEngine;

public class ClickControl : MonoBehaviour
{
    private int eatenUnhealthyFruits = 0;
    private int eatenHealthyFruits = 0;
    [SerializeField] private Force[] forceInstances;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.CompareTag("HealthyFruit"))
                {
                    Destroy(hit.transform.gameObject);
                    eatenHealthyFruits++;   
                }
                else if (hit.transform.gameObject.CompareTag("UnhealthyFruit"))
                {
                    Destroy(hit.transform.gameObject);
                    eatenUnhealthyFruits++;
                }
            }
        }

        if (eatenUnhealthyFruits >= 3)
        {
            foreach (var forceInstance in forceInstances)
            {
                forceInstance.stop = true;
            }
        }
    }
}