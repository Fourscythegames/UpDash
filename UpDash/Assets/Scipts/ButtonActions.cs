using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public GameObject backpanel, levelsPanel, player;
    //public List<RectTransform> UIElements = new List<RectTransform>();
    
    //private List<UIElementAttributes> uiElementsAttributes = new List<UIElementAttributes>();

    public List<UIScreens> uiScreens = new List<UIScreens>();
    
    private GameObject Obj_Short;
    private Vector2 OnS_Short;
    private Vector2 OffS_Short;
    
    void Start()
    {
        var big = 1;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            print(uiScreens[big].uiElementsAttributes.Count);
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OnS_Short.x, OnS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
    }
    
    public void ToMenu(){
        var big = 1;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            print(uiScreens[big].uiElementsAttributes.Count);
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OffS_Short.x, OffS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
        big = 2;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            print(uiScreens[big].uiElementsAttributes.Count);
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OffS_Short.x, OffS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
        big = 0;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OnS_Short.x, OnS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
        
        SwipeDetection.canSwipe = false;
    }

    public void ToGame(){
        
        var big = 0;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            //print(uiScreens[big].uiElementsAttributes.Count);
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OffS_Short.x, OffS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
        big = 1;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            //print(uiScreens[big].uiElementsAttributes.Count);
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OnS_Short.x, OnS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
        SwipeDetection.canSwipe = true;
    }

    public void ToLevels(){
        //LeanTween.moveLocal(backpanel, new Vector3(0,1920,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        //LeanTween.moveLocal(levelsPanel, new Vector3(0,0,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        var big = 0;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            print(uiScreens[big].uiElementsAttributes.Count);
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OffS_Short.x, OffS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
        big = 2;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            print(uiScreens[big].uiElementsAttributes.Count);
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OnS_Short.x, OnS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
    }

    public void ToGameLevelSpecific(GameObject gameObject){
        //LeanTween.moveLocal(backpanel, new Vector3(1080,0,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        //LeanTween.moveLocal(levelsPanel, new Vector3(1080,-1920,0), .75f).setEase(LeanTweenType.easeInOutCubic);

        SwipeDetection.canSwipe = true;

        LivePlayerStats.livePlayerStats.playerSpawnPoint = gameObject;
        LivePlayerStats.livePlayerStats.dead = true;
        player.SetActive(false);
        var big = 2;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            print(uiScreens[big].uiElementsAttributes.Count);
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OffS_Short.x, OffS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
        big = 1;
        for (int i = 0; i < uiScreens[big].uiElementsAttributes.Count; i++)
        {
            //print(uiScreens[big].uiElementsAttributes.Count);
            shortHand(i, big);
            LeanTween.moveLocal(Obj_Short, new Vector3(OnS_Short.x, OnS_Short.y, 0), .55f).setEase(LeanTweenType.easeInOutCubic);
        }
    }


    public void shortHand(int num, int big){
        OnS_Short = uiScreens[big].uiElementsAttributes[num].OnScreenLocation;
        OffS_Short = uiScreens[big].uiElementsAttributes[num].OffScreenLocation;
        Obj_Short = uiScreens[big].uiElementsAttributes[num].gameElement;
    }

    [System.Serializable] 
    public class UIScreens
    {
        public string name;
        public List<UIElementAttributes> uiElementsAttributes = new List<UIElementAttributes>();
        
    }
    [System.Serializable] 
    public class UIElementAttributes
    {
        public GameObject gameElement;
        public Vector2 OnScreenLocation;
        public Vector2 OffScreenLocation;
        
    }

    
}
