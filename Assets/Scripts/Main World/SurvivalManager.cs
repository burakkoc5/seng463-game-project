using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

//Created by following the tutorial at https://www.youtube.com/watch?v=hsJs7dvzgMM

public class SurvivalManager : MonoBehaviour
{
    [Header("Academic")]
    [SerializeField] private float _maxAcademy; //Max amount of academy the player can have
    [SerializeField] private float _academyDepletionRate; //Rate at which the academy depletes
    private float _currentAcademy; //Current amount of academy the player has
    
    [Header("Basic Needs")]
    [SerializeField] private float _maxBasicNeed; //Max amount of basic need the player can have
    [SerializeField] private float _basicNeedDepletionRate; //Rate at which the basic need depletes
    private float _currentBasicNeed; //Current amount of basic need the player has
    
    [Header("Social")]
    [SerializeField] private float _maxSocial; //Max amount of social the player can have
    [SerializeField] private float _socialDepletionRate; //Rate at which the social depletes
    private float _currentSocial; //Current amount of social the player has
    
    public static UnityAction OnPlayerLost; //Event to be called when the player loses

    private void Start()
    {
        //To lock the cursor after the minigames
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (!Singleton.isPlayerPlayedUniversityAtLeastOnce) //Checks if the player has played university at least once
        {
            _currentAcademy = _maxAcademy; //Sets the current academy to the max academy
            _currentBasicNeed = _maxBasicNeed; //Sets the current basic need to the max basic need
            _currentSocial = _maxSocial; //Sets the current social to the max social
            Singleton.isPlayerPlayedUniversityAtLeastOnce = true; //Sets the isPlayerPlayedUniversityAtLeastOnce to true
        }
        else
        {
            Debug.Log("Player played university at least once.");
            _currentAcademy = Singleton.currentAcademy; //Sets the current academy to the saved current academy
            _currentBasicNeed = Singleton.currentBasicNeed; //Sets the current basic need to the saved current basic need
            _currentSocial = Singleton.currentSocial; //Sets the current social to the saved current social
        }
    }

    private void Update()
    {
        _currentAcademy -= _academyDepletionRate * Time.deltaTime; //Depletes the academy
        _currentBasicNeed -= _basicNeedDepletionRate * Time.deltaTime; //Depletes the basic need
        _currentSocial -= _socialDepletionRate * Time.deltaTime; //Depletes the social
        
        Singleton.currentAcademy = _currentAcademy; //Saves the current academy
        Singleton.currentBasicNeed = _currentBasicNeed; //Saves the current basic need
        Singleton.currentSocial = _currentSocial; //Saves the current social

        if (_currentAcademy <= 0 || _currentBasicNeed <= 0 || _currentSocial <= 0) //Checks if the player has lost
        {
            OnPlayerLost?.Invoke(); //Invokes the OnPlayerLost event
            _currentAcademy = 0; //Sets the current academy to 0
            _currentBasicNeed = 0; //Sets the current basic need to 0
            _currentSocial = 0; //Sets the current social to 0
        } 
    }
    
    public void ReplenishAcademyBasicNeedSocial(float academyAmount, float basicNeedAmount, float socialAmount) //Method to replenish the player's needs
    {
        _currentAcademy += academyAmount; //Adds the academy amount to the current academy
        _currentBasicNeed += basicNeedAmount; //Adds the basic need amount to the current basic need
        _currentSocial += socialAmount; //Adds the social amount to the current social
        
        if (_currentAcademy > _maxAcademy) //Checks if the current academy is greater than the max academy
        {
            _currentAcademy = _maxAcademy;
        }
        if(_currentSocial > _maxSocial) //Checks if the current social is greater than the max social
        {
            _currentSocial = _maxSocial;
        }
        if (_currentBasicNeed > _maxBasicNeed) //Checks if the current basic need is greater than the max basic need
        {
            _currentBasicNeed = _maxBasicNeed;
        }
    }
}
