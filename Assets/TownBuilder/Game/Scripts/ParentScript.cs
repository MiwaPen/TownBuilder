using UnityEngine;
using System;

public class ParentScript : MonoBehaviour
{
    [SerializeField] private FailTrigger failTrigger;
    [SerializeField] private GameManager gameManager;
    public Action IncreesScore;
    public Action MoveCamera;

    private int _blockCount;
    private int _blockCountOld;

    private void Awake()
    {
        _blockCount = this.transform.childCount;
        _blockCountOld = this.transform.childCount;
        gameManager.ResetSceneEvent += ResetChildList;
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
        }else if (_blockCountOld > _blockCount)
        {
            _blockCountOld = _blockCount;
        }

    }

    private void ResetChildList()
    {
        if (this.transform.childCount > 1)
        {
            for (int i = this.transform.childCount - 1; i >= 1; i--)
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }
        }
    }
}
