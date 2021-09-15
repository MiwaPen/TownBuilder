using UnityEngine;
using System;

public class FailTrigger : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
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
                playerController.AccessSpawn();
                other.gameObject.GetComponent<BoxCollider>().enabled = false;

                other.gameObject.GetComponent<BlockScript>().DestroyBlockWithDelay();
            }
        }
    }
    public void ChangeTriggerPos(Transform transform)
    {
        ts.position = transform.position;
    }
}
