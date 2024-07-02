using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.33f;
    public PlayerSpawnerScript pss;

    private bool once;

    
    void Update()
    {
        if (LivePlayerStats.livePlayerStats.dead == true && once == false)
        {
            
            //StartCoroutine(TransitionIn());
            once = true;
        }
    }
    public void playerDied(){
        StartCoroutine(TransitionIn());
    }
    
    
    IEnumerator TransitionIn(){
        transition.SetTrigger("DarkIn");
        LivePlayerStats.livePlayerStats.dead = false;
        
        yield return new WaitForSeconds(transitionTime);
        once = false;
        pss.respawnPlayer();

        
        

    }
}
