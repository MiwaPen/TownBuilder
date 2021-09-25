using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource MusicSound;
    [SerializeField] AudioSource ClickSound;
    [SerializeField] AudioSource ClipSound;
    [SerializeField] AudioSource FailSound;
    [SerializeField] AudioSource endGameSound;

    public void Music()
    {
        MusicSound.Play();
    }
    public void Click()
    {
        ClickSound.Play();
    }
    public void Clip()
    {
        ClipSound.Play();
    }
    public void Fail()
    {
        FailSound.Play();
    }
    public void endGame()
    {
        endGameSound.Play();
    }
}
