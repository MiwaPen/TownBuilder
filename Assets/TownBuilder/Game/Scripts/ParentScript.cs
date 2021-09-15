using UnityEngine;
using System;

public class ParentScript : MonoBehaviour
{
    [SerializeField] FailTrigger failTrigger;
    [SerializeField] PlayerController playerController;
    public Action IncreesScore;
    public Action MoveCamera;

    private int _blockCount;
    private int _blockCountOld;

    private void Awake()
    {
        _blockCount = this.transform.childCount;
        _blockCountOld = this.transform.childCount;
    }
    
    public int GetChildrenCount()
    {
        return _blockCount;
    }
    private void OnTransformChildrenChanged()
    {
      
        _blockCount = this.transform.childCount;
        Transform lastChilhd = this.transform.GetChild(_blockCount-1);
        failTrigger.ChangeTriggerPos(lastChilhd);
        IncreesScore?.Invoke();
        if (_blockCountOld < _blockCount)
        {
            _blockCountOld = _blockCount;
            MoveCamera?.Invoke();
        }
        playerController.AccessSpawn();
    }
}
