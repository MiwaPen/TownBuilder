using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform blockSpawner;
    [SerializeField] private GameObject blockPrefubs;
    [SerializeField] private Transform parent;
    [SerializeField] private float SpawnOffSetValue = 0;
    private bool canSpawn = true;
    private Vector3 SpawnOffset;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canSpawn)
            {
                SpawnBlock();
            }
        }
    }
    private void SpawnBlock()
    {
        GameObject block = blockPrefubs;
        SpawnOffset = new Vector3(blockSpawner.position.x, blockSpawner.position.y - SpawnOffSetValue, blockSpawner.position.z);
        Instantiate(block, SpawnOffset, new Quaternion(0,0,0,0));
        canSpawn = false;
    }

    public void AccessSpawn()
    {
        canSpawn = true;
    }
}
