using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField]
    private bool isActiveScene = false;

    public bool IsActiveScene { get => isActiveScene; }

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
        instance = this;
    }

    public void SetSceneState(bool state)
    {
        isActiveScene = state;
    }
}
