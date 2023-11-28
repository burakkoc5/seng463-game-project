using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollector : MonoBehaviour
{
    [SerializeField] private ClickControl clickControlInstance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip eatSFX;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthyFruit") )
        {
            Destroy(other.transform.gameObject);
            audioSource.PlayOneShot(eatSFX);
            clickControlInstance.eatenHealthyFruits++;   
            clickControlInstance.eatenHealthyFruitsTMPUGUI.text = clickControlInstance.eatenHealthyFruits.ToString();
        }
        else if (other.CompareTag("UnhealthyFruit"))
        {
            Destroy(other.transform.gameObject);
            audioSource.PlayOneShot(eatSFX);
            clickControlInstance.eatenUnhealthyFruits++;
            clickControlInstance.eatenUnhealthyFruitsTMPUGUI.text = clickControlInstance.eatenUnhealthyFruits.ToString();
        }
    }
    
}
