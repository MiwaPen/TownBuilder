using UnityEngine;

public class SpawnerRotationChanger : MonoBehaviour
{
    private Rigidbody sphere;
    Vector3 m_EulerAngleVelocity;
    Quaternion _maxAngleQ;
    Quaternion _minAngleQ;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _speed;
    private bool left=false;
    private bool right=false;

    private void Awake()
    {
        right = true;
        sphere = this.GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 0, _speed);
        _maxAngleQ = new Quaternion(0, 0, _maxAngle, 0);
        _minAngleQ = new Quaternion(0, 0, _minAngle, 0);
    }

    private void FixedUpdate()
    {
        if (right)
        {
            if (Mathf.FloorToInt(sphere.rotation.eulerAngles.z)  == _minAngleQ.z)
            {
                left = true;
                right = false;
                ChangeMove();
            }
        }

        if (left)
        {           
            if (Mathf.FloorToInt(sphere.rotation.eulerAngles.z) == _maxAngleQ.z)
            {
                left = false;
                right = true;
                ChangeMove();
            }
        }
        Rotate();
    }

    private void Rotate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        sphere.MoveRotation(sphere.rotation * deltaRotation);
    }

    private void ChangeMove()
    {
        _speed = _speed * -1;
        m_EulerAngleVelocity = new Vector3(0, 0, _speed);
    }
}
