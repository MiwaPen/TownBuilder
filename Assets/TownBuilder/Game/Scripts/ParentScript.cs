using UnityEngine;
using System;

public class ParentScript : MonoBehaviour
{
    public Action IncreesScore;

    private int _blockCount;

    private void Awake()
    {
        _blockCount = this.transform.childCount;
    }
    
    public int GetChildrenCount()
    {
        return _blockCount;
    }
    private void OnTransformChildrenChanged()
    {
        _blockCount = this.transform.childCount;
        IncreesScore?.Invoke();
    }
}
