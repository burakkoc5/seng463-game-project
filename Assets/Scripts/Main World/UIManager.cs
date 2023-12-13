using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private SurvivalManager _survivalManager;
    [SerializeField] private Slider academySlider;
    [SerializeField] private Slider basicNeedSlider, socialSlider;

    private void FixedUpdate()
    {
        // _academySlider.value = _survivalManager.AcademyPercent;
        // basicNeedSlider.value = _survivalManager.BasicNeedPercent;
        // socialSlider.value = _survivalManager.SocialPercent;
        
        academySlider.value = Singleton.currentAcademy;
        basicNeedSlider.value = Singleton.currentBasicNeed;
        socialSlider.value = Singleton.currentSocial;
    }
}
