using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Food : MonoBehaviour
{
    [SerializeField] private float _basicNeedAmountToReplenish = 10f, _academyAmountToReplenish = 10f, _socialAmountToReplenish = 10f;
    
    private void Awake()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }

    private void Update()
    {
        transform.Rotate(transform.up, 20f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Player")) return;
        
        SurvivalManager survivalManager = other.gameObject.GetComponent<SurvivalManager>();
        
        if (survivalManager == null) return;
        
        survivalManager.ReplenishAcademyBasicNeedSocial(_academyAmountToReplenish, _basicNeedAmountToReplenish, _socialAmountToReplenish);
        Destroy(gameObject);
    }
}
