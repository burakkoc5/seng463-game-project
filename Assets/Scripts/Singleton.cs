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
}
