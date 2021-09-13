using UnityEngine;
using System;
public class BlockScript : MonoBehaviour
{
    private Rigidbody block;
    private Transform parent;
    public Action IncreesScore;
    private void Awake()
    {
        parent = FindObjectOfType<ParentScript>().transform;
        block = this.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Block")
        {
            Clip(collision.transform);
        }
    }

    private void Clip(Transform lastblock)
    {
        Vector3 newBlockXPos = new Vector3(block.transform.position.x, 0f, 0f);
        Vector3 LastBlockXPos = new Vector3(lastblock.transform.position.x, 0f, 0f);
        float dist = Vector3.Distance(newBlockXPos, LastBlockXPos);
        float blockSize = block.gameObject.GetComponent<BoxCollider>().size.x;
        if (dist <= blockSize/3) 
        {
            IncreesScore?.Invoke();
            block.isKinematic = true;
            block.gameObject.transform.SetParent(parent);
        }
        else
        {
            Destroy(block.gameObject);
            Destroy(lastblock.gameObject);
        }
    }
}
