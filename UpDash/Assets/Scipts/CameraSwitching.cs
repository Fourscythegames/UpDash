using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitching : MonoBehaviour
{
    //public static CameraSwitching CameraSwitching Instance { get; set;} 
    public static int cameraPriorityState = 0;
    [SerializeField]
    private CinemachineVirtualCamera gameCam;

    [SerializeField]
    private CinemachineVirtualCamera menuCam;

    [SerializeField]
    private CinemachineVirtualCamera towerCam;

    private int camIndex;
    //0 = game, 1 = menu, 2 = tower 
    

    public void SwitchPriority(int switchVal){
        if(switchVal == 0){
            gameCam.Priority = 1;
            menuCam.Priority = 0;
            towerCam.Priority = 0;
            cameraPriorityState = 0;
        }

        if(switchVal == 1){
            gameCam.Priority = 0;
            menuCam.Priority = 1;
            towerCam.Priority = 0;
            cameraPriorityState = 1;
        }
        if(switchVal == 2){
            gameCam.Priority = 0;
            menuCam.Priority = 0;
            towerCam.Priority = 1;
            cameraPriorityState = 2;
        }
    }


}
