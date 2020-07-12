using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    HighScoreManager highscore;
    List<LevelButton> buttons = new List<LevelButton>();

    void Start()
    {
        highscore = HighScoreManager.instance;
        buttons.AddRange(GetComponentsInChildren<LevelButton>());

        UpdateLevels();
    }

    void UpdateLevels()
    {
        int levelID = 0;
        foreach (LevelButton level in buttons)
        {
            levelID++;
            string levelName = $"Level_{levelID}";
            string previousLevelName = $"Level_{levelID-1}";
            Score levelScore = highscore.GetHighestScore(levelName);
            Score previousLevelScore = highscore.GetHighestScore(previousLevelName);

            level.SetValues(levelName, levelScore, previousLevelScore);
        }
    }
}
