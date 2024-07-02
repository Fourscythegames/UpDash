using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DataManager;

public class GameDataManagerScript : MonoBehaviour
{
    public SaveDataObject saveDataObject;
    private string path;

    public bool FactoryResetButton;
    
    //private static GameDataManagerScript instance;

    


    private void Awake()
    {
        SetUpPath();
        
        
      
    }
    private void Update() {
        if(FactoryResetButton == true){
            FactoryResetButton = false;
            factoryReset();
        }
        if(Input.GetKeyDown(KeyCode.S)){ 
               
            //SaveDataObject.saveInfo = SaveDataObject.saveInfo;
            GameData.SaveData(saveDataObject,path,false);
            
            print("Just Saved");
        }
        if(Input.GetKeyDown(KeyCode.L)){
            
            LoadSavedData();
            print("Fake Load  " + saveDataObject.saveInfo.currentVerticalLoction);
        }
    }

    public void UpdateDataSave(float d, GameObject c, float h){
        //print("Form Update date save " + d + "   " + c);
        saveDataObject.saveInfo = new SaveInfo{currentVerticalLoction = d, currentCheckPoint = c, highestVerticalLocation = h};
        GameData.SaveData(saveDataObject,path,false);
    }
    public void LoadSavedData(){
        saveDataObject = GameData.LoadData(saveDataObject,path,false) as SaveDataObject;
        // d = saveDataObject.saveInfo.currentVerticalLoction;
        // c = saveDataObject.saveInfo.currentCheckPoint;
        // h = saveDataObject.saveInfo.highestVerticalLocation;
        //print("Form Load  " +  SaveDataObject.saveInfo.deaths + "   " + c);


    }
    public void SaveAllData(GameObject player, float highestVerticalLocations){
        saveDataObject.saveInfo.currentVerticalLoction = player.transform.position.y;
        saveDataObject.saveInfo.highestVerticalLocation = highestVerticalLocations;
        saveDataObject.saveInfo.currentCheckPoint = LivePlayerStats.livePlayerStats.playerSpawnPoint;
        saveDataObject.saveInfo.currentHighestCheckPoint = LivePlayerStats.livePlayerStats.highestSpawnPoint;
        GameData.SaveData(saveDataObject,path,false);
    }
    public void SetUpPath(){
        path = Application.persistentDataPath + "/Save.dat";//
        //print(Application.persistentDataPath);
    }

    [System.Serializable]
    public class SaveDataObject {
        public SaveInfo saveInfo;
        
        //public OtherInfo otherInfo;
    }
    [System.Serializable]
    public class SaveInfo {
        public float currentVerticalLoction;
        public float highestVerticalLocation;
        public GameObject currentCheckPoint;
        public GameObject currentHighestCheckPoint;
        
        
    }
    public void factoryReset(){
        float cv = 0f;
        float hvl = 0f;
        var obj = GameObject.Find("CheckPoint (1)");

        saveDataObject.saveInfo.currentVerticalLoction = cv;
        saveDataObject.saveInfo.highestVerticalLocation = hvl;
        saveDataObject.saveInfo.currentCheckPoint = obj;
        saveDataObject.saveInfo.currentHighestCheckPoint = obj;
        GameData.SaveData(saveDataObject,path,false);
    }
    
}
