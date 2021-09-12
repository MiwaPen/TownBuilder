using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private Rigidbody block;

    private void Awake()
    {
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
            block.isKinematic = true;
        }
        else
        {
            Destroy(block.gameObject);
            Destroy(lastblock.gameObject);
        }
    }
}
