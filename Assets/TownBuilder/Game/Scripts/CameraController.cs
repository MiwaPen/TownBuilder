using UnityEngine;
using System;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera1;
    [SerializeField] private CinemachineVirtualCamera _camera2;
    [SerializeField] private ParentScript parentScript;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float _camera1PosY;
    [SerializeField] private float _camera2PosY;

    private void Awake()
    {
        parentScript.MoveCamera += SwitchCamera;
        gameManager.ResetSceneEvent += ResetCamPos;
        _camera1.Priority = 1;
        _camera2.Priority = 0;
    }

    public void SwitchCamera()
    {
        if (_camera1.Priority > _camera2.Priority)
        {
            _camera2.Priority = _camera1.Priority+1;
            Invoke("UpFirstCam", 1.2f);
        }
        else
        {
            _camera1.Priority = _camera2.Priority + 1;
            Invoke("UpSecondCam", 1.2f);
        }
    }

    private void UpFirstCam()
    {
        _camera1.transform.position = new Vector3(_camera2.transform.position.x, _camera2.transform.position.y + 4, _camera2.transform.position.z);
    }
    private void UpSecondCam()
    {
        _camera2.transform.position = new Vector3(_camera1.transform.position.x, _camera1.transform.position.y + 4, _camera1.transform.position.z);
    }

    private void ResetCamPos()
    {
        _camera1.transform.position = new Vector3(_camera1.transform.position.x, _camera1PosY, _camera1.transform.position.z);
        _camera2.transform.position = new Vector3(_camera2.transform.position.x, _camera2PosY, _camera2.transform.position.z);
        _camera1.Priority = 1;
        _camera2.Priority = 0;
    }

}
