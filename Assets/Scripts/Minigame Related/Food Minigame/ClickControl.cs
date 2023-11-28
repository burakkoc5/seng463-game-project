using System;
using TMPro;
using UnityEngine;

public class ClickControl : MonoBehaviour
{
    [SerializeField] private Force[] forceInstances;
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
        // if (Input.GetMouseButtonDown(0) && gameCondition)
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //
        //     if (Physics.Raycast(ray, out hit, 100))
        //     {
        //         if (hit.transform.gameObject.CompareTag("HealthyFruit"))
        //         {
        //             Destroy(hit.transform.gameObject);
        //             eatenHealthyFruits++;   
        //             eatenHealthyFruitsTMPUGUI.text = eatenHealthyFruits.ToString();
        //         }
        //         else if (hit.transform.gameObject.CompareTag("UnhealthyFruit"))
        //         {
        //             Destroy(hit.transform.gameObject);
        //             eatenUnhealthyFruits++;
        //             eatenUnhealthyFruitsTMPUGUI.text = eatenUnhealthyFruits.ToString();
        //         }
        //     }
        //     
        // }

        if (eatenUnhealthyFruits >= 3)
        {
            gameCondition = false;
            foreach (var forceInstance in forceInstances)
            {
                forceInstance.stop = true;
            }
        }
    }
}