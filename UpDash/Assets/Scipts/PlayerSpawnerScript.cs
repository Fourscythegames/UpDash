using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawnerScript : MonoBehaviour
{
    public GameObject player;

    public GameDataManagerScript gameDataManagerScript;

    public static PlayerSpawnerScript _playerSpawnerScript {get; private set;}

    public List<GameObject> spawnPositions;

    private LivePlayerStats LPS;

    public Button respawnButton;

    private bool once;
    private bool once2;

    public ButtonActions buttonActions;


    void Start()
    {
        player.transform.position = LivePlayerStats.livePlayerStats.playerSpawnPoint.transform.position;
        LPS = this.GetComponent<LivePlayerStats>();
        
    }

    
    public void  respawnPlayer(){
        player.transform.position = LivePlayerStats.livePlayerStats.playerSpawnPoint.transform.position;
        LivePlayerStats.livePlayerStats.dead = false;
        player.SetActive(true);
    }
    public void  respawnPlayerAtHighest(){
        respawnButton.interactable = false;
        LivePlayerStats.livePlayerStats.dead = true;
        player.SetActive(false);
        GameObject.Find("Transitions").GetComponent<TransitionManager>().playerDied();
       
        hideButton();
        Invoke("ExecuteAfterDelay", 0.5f);
            
        
        
        
        
    }
    void ExecuteAfterDelay()
    {
        player.transform.position = LivePlayerStats.livePlayerStats.highestSpawnPoint.transform.position;
        LivePlayerStats.livePlayerStats.dead = false;
        player.SetActive(true);
        once2 = false;
        respawnButton.interactable = true;
        
    }

    private void Update()
    {
        if(player.transform.position.y < gameDataManagerScript.saveDataObject.saveInfo.currentHighestCheckPoint.transform.position.y-10 && once == false){
            once = true;
            buttonActions.ShowRespawnButton();
        }else if(player.transform.position.y >= gameDataManagerScript.saveDataObject.saveInfo.currentHighestCheckPoint.transform.position.y-10 && once == true)
        {
            once = false;
        }
        
    }
    private void hideButton(){
        buttonActions.HideRespawnButton();
        
    }
}
