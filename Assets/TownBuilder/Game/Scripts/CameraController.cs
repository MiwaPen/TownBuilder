using UnityEngine;
using System;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Action ChangeViewPoint;
    [SerializeField] CinemachineVirtualCamera _camera1;
    [SerializeField] CinemachineVirtualCamera _camera2;
    [SerializeField] ParentScript parentScript;

    private void Awake()
    {
        parentScript.MoveCamera += SwitchCamera;
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

}
