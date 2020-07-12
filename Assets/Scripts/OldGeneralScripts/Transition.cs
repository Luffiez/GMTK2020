using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public static Transition instance;

    Animator anim;
    string sceneToLoad = "Menu";
    [SerializeField]
    AudioClip ClickSound;

    private void Awake()
    {
        if (instance)
            Destroy(transform.root.gameObject);
        else
            instance = this;

        DontDestroyOnLoad(transform.root);
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        anim.SetBool("TransitionTo", false);
        if(SceneManager.GetActiveScene().name != "Menu")
        {
            MusicManager.Instance.ChangeBgmSong(MusicManager.Instance.gameMusic);
        }
        else
        {
            MusicManager.Instance.ChangeBgmSong(MusicManager.Instance.menuMusic);
        }
    }

    public void Play(int level)
    {
        MusicManager.Instance.PlayOneShot(ClickSound,2);
        sceneToLoad = $"Level_{level}";
        anim.SetBool("TransitionTo", true);
        GameManager.instance.NewScene();
    }

    public void Menu()
    {
        MusicManager.Instance.PlayOneShot(ClickSound,2);
        sceneToLoad = "Menu";
        anim.SetBool("TransitionTo", true);
    }

    void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
            Debug.LogWarning("sceneToLoad has not been specified!");
    }

    public void Quit()
    {
        MusicManager.Instance.PlayOneShot(ClickSound,2);
        Application.Quit();
    }
}
