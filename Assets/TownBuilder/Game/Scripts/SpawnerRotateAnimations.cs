using UnityEngine;

public class SpawnerRotateAnimations : MonoBehaviour
{
    const string _movingRight = "SpawnerFirst";
    const string _movingLeft = "MovingLeft";
    private Animation anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
        PlayMovingRightAnim();
    }

    public void PlayMovingRightAnim()
    {
        anim.Play(_movingRight,PlayMode.StopAll);
    }

    public void PlayMovingLeftAnim()
    {
        anim.Play(_movingLeft, PlayMode.StopAll);
    }
}
