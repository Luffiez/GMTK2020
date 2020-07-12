using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField]
    AudioClip audioClip;
    [SerializeField]
    float Volume;
    void Start()
    {
        StartMusic();
    }

    void StartMusic()
    {
        MusicManager.Instance.ChangeBgmSong(audioClip);
        if (Volume != 0)
            MusicManager.Instance.ChangeBgmVolume(Volume);
    }

}
