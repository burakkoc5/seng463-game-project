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
        //To lock the cursor after the minigames
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (!Singleton.isPlayerPlayedUniversityAtLeastOnce)
        {
            _currentAcademy = _maxAcademy;
            _currentBasicNeed = _maxBasicNeed;
            _currentSocial = _maxSocial;
            Singleton.isPlayerPlayedUniversityAtLeastOnce = true;
        }
        else
        {
            Debug.Log("Player played university at least once.");
            _currentAcademy = Singleton.currentAcademy;
            _currentBasicNeed = Singleton.currentBasicNeed;
            _currentSocial = Singleton.currentSocial;
        }
    }

    private void Update()
    {
        _currentAcademy -= _academyDepletionRate * Time.deltaTime;
        _currentBasicNeed -= _basicNeedDepletionRate * Time.deltaTime;
        _currentSocial -= _socialDepletionRate * Time.deltaTime;
        
        Singleton.currentAcademy = _currentAcademy;
        Singleton.currentBasicNeed = _currentBasicNeed;
        Singleton.currentSocial = _currentSocial;

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
