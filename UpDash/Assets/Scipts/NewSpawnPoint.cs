using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawnPoint : MonoBehaviour
{

    bool once;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Collider" && once==false){
            
            LivePlayerStats.livePlayerStats.playerSpawnPoint = this.gameObject;
            once = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //print(col.gameObject.name);
        if(col.gameObject.name == "Collider" && once==true){
           
            once = false;
        }
    }
}
