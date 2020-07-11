using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField]
    private bool isActiveScene = false;

    private int numberOfHonks;
    private float timer = 0;

    internal Action<float> timerUpdate;
    internal Action<int> honkUpdate;

    public bool IsActiveScene { get => isActiveScene; }

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
        instance = this;
    }

    private void Update()
    {
        if (IsActiveScene)
        {
            timer += Time.deltaTime;
            timerUpdate.Invoke(timer);
        }
    }

    public void SetSceneState(bool state)
    {
        isActiveScene = state;
    }

    public void IncreaseHonks()
    {
        numberOfHonks++;
        honkUpdate.Invoke(numberOfHonks);
    }

    public void CompleteLevel()
    {
        Debug.Log("Level Complete!");
        SetSceneState(false);

        HighScoreManager.instance.AddToScoreboard(SceneManager.GetActiveScene().name, numberOfHonks, timer);
        Invoke("RestartScene", 3f);
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
