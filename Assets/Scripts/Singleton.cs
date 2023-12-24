using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    
    public static float currentAcademy;
    public static float currentBasicNeed;
    public static float currentSocial;
    [HideInInspector] public static bool isPlayerPlayedUniversityAtLeastOnce = false;
    
    private static bool isInstatiatedBefore = false; // To prevent duplication of Singleton game object (Singleton Pattern)
    
    void Start()
    {
        if(!isInstatiatedBefore) //Singleton Pattern
        {
            DontDestroyOnLoad(this);
            isInstatiatedBefore = true;
        }
    }
    
    public static void increaseCurrentAcademy(float academy)
    {
        currentAcademy += academy;
        if(currentAcademy >= 100) //To prevent exceeding 100
            currentAcademy = 100;
        if(currentAcademy <= 0) //To prevent going below 0
            currentAcademy = 0;
    }
    
    public static void increaseCurrentBasicNeed(float basicNeed)
    {
        currentBasicNeed += basicNeed;
        if(currentBasicNeed >= 100) //To prevent exceeding 100
            currentBasicNeed = 100;
        if(currentBasicNeed <= 0) //To prevent going below 0
            currentBasicNeed = 0;
    }
    
    public static void increaseCurrentSocial(float social)
    {
        currentSocial += social;
        if(currentSocial >= 100) //To prevent exceeding 100
            currentSocial = 100;
        if(currentSocial <= 0) //To prevent going below 0
            currentSocial = 0;
    }
}
