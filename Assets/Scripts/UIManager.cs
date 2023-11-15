using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private SurvivalManager _survivalManager;
    [SerializeField] private Slider _academySlider, basicNeedSlider, socialSlider;

    private void FixedUpdate()
    {
        _academySlider.value = _survivalManager.AcademyPercent;
        basicNeedSlider.value = _survivalManager.BasicNeedPercent;
        socialSlider.value = _survivalManager.SocialPercent;
    }
}
