using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePlayerStats : MonoBehaviour
{
    public static LivePlayerStats livePlayerStats {get ; set;}


    [Header("Live Stats")]
    public int dashCount;
    public bool dashing;
    public bool dead;
    public GameObject playerSpawnPoint;

    [Space(5)]
    [Header("Static Stats")]

    public int maxDashCount;

    
    // void Awake()
    // {
    //     if(playerSpawnPoint == ){
    //         playerSpawnPoint = 
    //     }
    // }
    void Start()
    {
        
        livePlayerStats = this;
    }
}
