using UnityEngine;

public class Goal : MonoBehaviour
{
    GameManager gm;
    [SerializeField]
    AudioClip winClip;
    [SerializeField]
    float volume;
    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Gesse"))
        {
            MusicManager.Instance.PlayOneShot(winClip, volume);
            gm.CompleteLevel();
        }
    }
}
