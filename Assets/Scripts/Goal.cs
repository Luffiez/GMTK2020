using UnityEngine;

public class Goal : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Gesse"))
        {
            gm.CompleteLevel();
        }
    }
}
