using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Gesse"))
        {
            Debug.Log("Level Complete!");
            //Disable objects event
            Invoke("RestartScene", 3f);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
