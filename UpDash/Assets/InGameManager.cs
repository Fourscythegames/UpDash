using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public GameDataManagerScript gameDataManagerScript;

    public GameObject player;
    private PlayerChecks playerChecks;

    public float currentHighestVerticalLocation;

    public float interval = 2.0f;


    private void Awake()
    {
        playerChecks = player.GetComponent<PlayerChecks>();
        currentHighestVerticalLocation = player.GetComponent<LivePlayerStats>().playerSpawnPoint.transform.position.y;
        gameDataManagerScript.LoadSavedData();
        if(gameDataManagerScript.saveDataObject.saveInfo.highestVerticalLocation > currentHighestVerticalLocation){
            currentHighestVerticalLocation = gameDataManagerScript.saveDataObject.saveInfo.highestVerticalLocation;
        }
        //player.GetComponent<LivePlayerStats>().livePlayerStats.playerSpawnPoint = gameDataManagerScript.saveDataObject.saveInfo.currentCheckPoint;
        
        
    }
    private void Update()
    {
        if(playerChecks.grounded){
            
            if(player.transform.position.y > currentHighestVerticalLocation){
                currentHighestVerticalLocation = player.transform.position.y;
            }
            
        }
    }
    public void startRepeating(){
        StartCoroutine(RepeatTask());
    }

    public IEnumerator RepeatTask()
    {
        while (true)
        {
            // Your code to repeat
            float val1 = player.transform.position.y;
            float roundedval1 = Mathf.Round(val1 * 100f) / 100f;

            float val2 = currentHighestVerticalLocation;
            float roundedval2 = Mathf.Round(val2 * 100f) / 100f;

            gameDataManagerScript.UpdateDataSave(roundedval1, player.GetComponent<LivePlayerStats>().playerSpawnPoint, roundedval2);

            // Wait for the specified interval
            yield return new WaitForSeconds(interval);
        }
    }
}
