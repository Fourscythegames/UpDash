using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    public GameObject player;

    public static PlayerSpawnerScript _playerSpawnerScript {get; private set;}

    public List<GameObject> spawnPositions;

    private LivePlayerStats LPS;


    void Start()
    {
        player.transform.position = spawnPositions[0].transform.position;
        LPS = this.GetComponent<LivePlayerStats>();
        
    }

    
    public void  respawnPlayer(){
        player.transform.position = spawnPositions[0].transform.position;
        LivePlayerStats.livePlayerStats.dead = false;
        player.SetActive(true);
    }
}
