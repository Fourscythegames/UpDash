using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DataManager;

public class GameDataManagerScript : MonoBehaviour
{
    public SaveDataObject saveDataObject;
    private string path;

    //private static GameDataManagerScript instance;

    


    private void Awake()
    {
        SetUpPath();
      
    }
    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.S)){ 
               
            //SaveDataObject.saveInfo = SaveDataObject.saveInfo;
            GameData.SaveData(saveDataObject,path,false);
            print("Just Saved");
        }
        if(Input.GetKeyDown(KeyCode.L)){
            // float d;
            // GameObject c;
            // float h;

            LoadSavedData();
            //print(d +"  "+ c);
            //SaveDataObject = GameData.LoadData(SaveDataObject,path,false) as SaveDataObject;
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
    public void SetUpPath(){
        path = Application.persistentDataPath + "/Save.dat";//
        //print(Application.persistentDataPath);
    }

    [System.Serializable]
    public class SaveDataObject {
        public SaveInfo saveInfo;
    }
    [System.Serializable]
    public class SaveInfo {
        public float currentVerticalLoction;
        public GameObject currentCheckPoint;
        public float highestVerticalLocation;
    }
}
