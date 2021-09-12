using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject blockSpawner;
    [SerializeField] private GameObject blockPrefubs;
    [SerializeField] private Transform parent;
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBlock();
        }
    }
    private void SpawnBlock()
    {
        GameObject block = blockPrefubs;
        Instantiate(block, blockSpawner.transform.position, new Quaternion(0,0,0,0),parent);
    }
}
