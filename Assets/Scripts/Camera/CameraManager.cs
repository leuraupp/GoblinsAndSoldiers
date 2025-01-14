using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using Utils.Core.Singleton;

public class CameraManager : Singleton<CameraManager> {
    
    public List<CinemachineCamera> cameras;
    public float transitionTime = 1.0f;

    public void SetCameraLevel(string levelName) {
        switch (levelName) {
            case "level02":
            StartCoroutine(SwitchCameras(cameras[0], cameras[1]));
            break;
            case "level03":
            StartCoroutine(SwitchCameras(cameras[1], cameras[2]));
            break;
            case "level04":
            StartCoroutine(SwitchCameras(cameras[2], cameras[3]));
            break;
            case "level05":
            StartCoroutine(SwitchCameras(cameras[3], cameras[4]));
            break;
        }
    }

    private IEnumerator SwitchCameras(CinemachineCamera camFrom, CinemachineCamera camTo) {

        camFrom.Priority = 9;
        camTo.Priority = 10;
        yield return new WaitForSeconds(transitionTime);
        camFrom.Priority = 0;
    }

}
