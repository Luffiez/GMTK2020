using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    [SerializeField]
    Animator levelAnimatior;
    public void Play(int level)
    {
        Transition.instance.Play(level);
    }

    public void Exit()
    {
        Transition.instance.Quit();
    }

}
