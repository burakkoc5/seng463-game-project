using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    
    public float currentAcademy;
    public float currentBasicNeed;
    public float currentSocial;
    [HideInInspector] public bool isPlayerPlayedUniversityAtLeastOnce = false;
    
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
}
