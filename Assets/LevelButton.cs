using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    TMP_Text levelName;

    [SerializeField]
    TMP_Text highscore;

    [SerializeField]
    Button button;

    public void SetValues(string name, Score score, Score previousCompleted)
    {
        levelName.text = name;
        
        if(score != null)
        {
            string minutes = Mathf.Floor(score.timer / 60).ToString("00");
            string seconds = (score.timer % 60).ToString("00");

            highscore.text = $"Highscore\n{ minutes}:{ seconds}";
        }
        else
        {
            highscore.text = $"Highscore\n???";

            if (!name.Equals("Level_1") && previousCompleted == null)
            {
                button.interactable = false;
            }
        }
    }
}
