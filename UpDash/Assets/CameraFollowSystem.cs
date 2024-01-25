using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraFollowSystem : MonoBehaviour
{

    public GameObject player;
    
    public float cameraXPos;
    public CinemachineVirtualCamera vcam;
    public GameObject cameraStartPos; 
    
    public bool once;
    
    
    void LateUpdate()
    {
        if(once == false){
            vcam.ForceCameraPosition(cameraStartPos.transform.position, cameraStartPos.transform.rotation);
            once = true;
        }
        
        transform.position = new Vector2(cameraXPos,player.transform.position.y);
    }
}
