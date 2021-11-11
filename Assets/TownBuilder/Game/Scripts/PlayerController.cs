using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform blockSpawner;
    [SerializeField] private GameObject blockPrefabs;
    [SerializeField] private float SpawnOffSetValue = 0;
    private bool canSpawn = false;
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
        GameObject block = blockPrefabs;
        SpawnOffset = new Vector3(blockSpawner.position.x, blockSpawner.position.y - SpawnOffSetValue, blockSpawner.position.z);
        Instantiate(block, SpawnOffset, new Quaternion(0,0,0,0));
        canSpawn = false;
    }

    public void AccessSpawnTrue()
    {
        canSpawn = true;
    }

    public void AccessSpawnFalse()
    {
        canSpawn = false;
    }
}
