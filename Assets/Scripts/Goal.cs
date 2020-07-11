using UnityEngine.SceneManagement;
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
            Debug.Log("Level Complete!");
            gm.SetSceneState(false);
            Invoke("RestartScene", 3f);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
