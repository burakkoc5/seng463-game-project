using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class SurvivalManager : MonoBehaviour
{
    [Header("Academic")]
    [SerializeField] private float _maxAcademy;
    [SerializeField] private float _academyDepletionRate;
    private float _currentAcademy;
    public float AcademyPercent { get { return (_currentAcademy / _maxAcademy) * 100; } }
    
    [Header("Basic Needs")]
    [SerializeField] private float _maxBasicNeed;
    [SerializeField] private float _basicNeedDepletionRate;
    private float _currentBasicNeed;
    public float BasicNeedPercent { get { return (_currentBasicNeed / _maxBasicNeed) * 100; } }
    
    [Header("Social")]
    [SerializeField] private float _maxSocial;
    [SerializeField] private float _socialDepletionRate;
    private float _currentSocial;
    public float SocialPercent { get { return (_currentSocial / _maxSocial) * 100; } }
    
    [Header("Player References")]
    [SerializeField] private StarterAssetsInputs _playerInput;

    public static UnityAction OnPlayerLost;

    private void Start()
    {
        Singleton.Instance.isPlayerPlayedUniversityAtLeastOnce = true;
        
        if (Singleton.Instance.isPlayerPlayedUniversityAtLeastOnce)
        {
            _currentAcademy = _maxAcademy;
            _currentBasicNeed = _maxBasicNeed;
            _currentSocial = _maxSocial;
        }
        else
        {
            _currentAcademy = Singleton.Instance.currentAcademy;
            _currentBasicNeed = Singleton.Instance.currentBasicNeed;
            _currentSocial = Singleton.Instance.currentSocial;
        }
    }

    private void Update()
    {
        _currentAcademy -= _academyDepletionRate * Time.deltaTime;
        _currentBasicNeed -= _basicNeedDepletionRate * Time.deltaTime;
        _currentSocial -= _socialDepletionRate * Time.deltaTime;
        
        Singleton.Instance.currentAcademy = _currentAcademy;
        Singleton.Instance.currentBasicNeed = _currentBasicNeed;
        Singleton.Instance.currentSocial = _currentSocial;

        if (_currentAcademy <= 0 || _currentBasicNeed <= 0 || _currentSocial <= 0)
        {
            OnPlayerLost?.Invoke();
            _currentAcademy = 0;
            _currentBasicNeed = 0;
            _currentSocial = 0;
        }
    }
    
    public void ReplenishAcademyBasicNeedSocial(float academyAmount, float basicNeedAmount, float socialAmount)
    {
        _currentAcademy += academyAmount;
        _currentBasicNeed += basicNeedAmount;
        _currentSocial += socialAmount;
        
        if (_currentAcademy > _maxAcademy)
        {
            _currentAcademy = _maxAcademy;
        }
        if(_currentSocial > _maxSocial)
        {
            _currentSocial = _maxSocial;
        }
        if (_currentBasicNeed > _maxBasicNeed)
        {
            _currentBasicNeed = _maxBasicNeed;
        }
    }
}
