using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    [SerializeField]
    Animator levelAnimatior;
    public void Play()
    {
        Transition.instance.Play();
    }

    public void Exit()
    {
        Transition.instance.Quit();
    }

}
