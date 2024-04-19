using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public GameObject backpanel, levelsPanel, player;
    public void ToMenu(){
        LeanTween.moveLocal(backpanel, new Vector3(0,0,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.moveLocal(levelsPanel, new Vector3(0,-1920,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        SwipeDetection.canSwipe = false;
    }

    public void ToGame(){
        LeanTween.moveLocal(backpanel, new Vector3(1080,0,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.moveLocal(levelsPanel, new Vector3(1080,-1920,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        SwipeDetection.canSwipe = true;
    }

    public void ToLevels(){
        LeanTween.moveLocal(backpanel, new Vector3(0,1920,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.moveLocal(levelsPanel, new Vector3(0,0,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        
    }

    public void ToGameLevelSpecific(GameObject gameObject){
        LeanTween.moveLocal(backpanel, new Vector3(1080,0,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.moveLocal(levelsPanel, new Vector3(1080,-1920,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        SwipeDetection.canSwipe = true;

        LivePlayerStats.livePlayerStats.playerSpawnPoint = gameObject;
        LivePlayerStats.livePlayerStats.dead = true;
        player.SetActive(false);
    }
}
