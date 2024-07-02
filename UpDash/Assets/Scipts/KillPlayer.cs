using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private bool once;
    public GameObject player;
    //public TransitionManager transitionManager;
    void OnTriggerEnter2D(Collider2D col)
    {
        //print(col.gameObject.name);
        if(col.gameObject.name == "Collider" && once==false){
            LivePlayerStats.livePlayerStats.dead = true;
            GameObject.Find("Transitions").GetComponent<TransitionManager>().playerDied();
            once = true;
            player.SetActive(false);
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
