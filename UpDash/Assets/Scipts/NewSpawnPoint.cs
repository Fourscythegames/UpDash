using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawnPoint : MonoBehaviour
{
    bool once;

    public float colorIndexH = 10;
    public float colorIndexS = 76;
    public float colorIndexV = 85;
    
    public  float colorIndexA;

    public float c1,c2,c3,c4;
    
    void Start()
    {
        
        this.GetComponent<SpriteRenderer> ().color = new Color(colorIndexH,colorIndexS,colorIndexV,colorIndexA);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Collider" && once==false){
            
            this.GetComponent<SpriteRenderer> ().color = new Color(c1,c2,c3,c4);
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
