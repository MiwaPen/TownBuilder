using UnityEngine;

public class FailTrigger : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private AudioController audioController;
    [SerializeField] private GameManager gameManager;
    private Transform ts;

    private void Awake()
    {
        ts = this.gameObject.GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (rigidbody.isKinematic==false)
            {
                audioController.Fail();
                playerController.AccessSpawnTrue();
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                other.gameObject.GetComponent<BlockScript>().DestroyBlockWithDelay();
                gameManager.UpdateHP();
            }
        }
    }
    public void ChangeTriggerPos(Transform transform)
    {
        ts.position = transform.position;
    }
}
