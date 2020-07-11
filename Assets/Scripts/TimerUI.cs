using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TMP_Text timerText;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
        gm.timerUpdate += UpdateTimer;
    }

    public void UpdateTimer(float timer)
    {
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        timerText.text = $"{minutes}:{seconds}";
    }
}
