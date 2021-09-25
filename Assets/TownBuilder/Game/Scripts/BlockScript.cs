using UnityEngine;
public class BlockScript : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private AudioController audioController;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float DestroyDelay = 5; 
    private Rigidbody block;
    private Transform parent;
 
    private void Awake()
    {
        parent = FindObjectOfType<ParentScript>().transform;
        block = this.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Block" || collision.gameObject.tag == "StartBlock")
        {
            if (block.isKinematic == false)
            {
                Invoke("SetSpawnAccess", 0.3f);
                Clip(collision.transform);
            }
        }
    }

    private void Clip(Transform lastblock)
    {
      
        Vector3 newBlockXPos = new Vector3(block.transform.position.x, 0f, 0f);
        Vector3 LastBlockXPos = new Vector3(lastblock.transform.position.x, 0f, 0f);
        float dist = Vector3.Distance(newBlockXPos, LastBlockXPos);
        float blockSize = block.gameObject.GetComponent<BoxCollider>().size.x;
        if (dist <= blockSize/2.5) 
        {
            block.transform.position = new Vector3(block.transform.position.x, lastblock.position.y + blockSize, lastblock.position.z);
            block.transform.Rotate(lastblock.rotation.eulerAngles);
            block.isKinematic = true;
            block.gameObject.transform.SetParent(parent);
            audioController.Clip();
        }
        else
        {
            playerController.AccessSpawnTrue();
            gameManager.UpdateHP();
            Destroy(block.gameObject);
            if (lastblock.gameObject.tag == "Block")
            {
                Destroy(lastblock.gameObject);
            }
            audioController.Fail();
        }
    }

    private void SetSpawnAccess()
    {
        playerController.AccessSpawnTrue();
    }
    public void DestroyBlockWithDelay()
    {
        Invoke("DestroyBlock", DestroyDelay);
    }

    private void DestroyBlock()
    {
        Destroy(this.gameObject);
    }
}
