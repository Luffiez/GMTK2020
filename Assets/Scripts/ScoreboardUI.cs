using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreboardUI : MonoBehaviour
{

    public GameObject textPrefab;
    public Transform textPanel;

    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = HighScoreManager.instance.Scoreboard;

        LoadscoreboardScores();
    }

    void LoadscoreboardScores()
    {
        int j = 0;
        // NEED TO CHOOSE WHICH LEVEL TO VIEW SCORE ON.

        //for (int i = scoreboard.levels.Count - 1; i >= 0; i--)
        //{
        //    GameObject textObject = Instantiate(textPrefab, textPanel);
        //    TMP_Text text = textObject.GetComponent<TMP_Text>();
        //    text.text = $"{GetPlacementName(j)} \nTime: {scoreboard.scoreList[i].timer} \nHonks: {scoreboard.scoreList[i].honks} \nDate: {scoreboard.scoreList[i].date}";
        //    j++;
        //}
    }

    string GetPlacementName(int id)
    {
        switch (id)
        {
            case 0:
                return "- First Place -";
            case 1:
                return "- Second Place -";
            case 2:
                return "- Third Place -";
            case 3:
                return "- Fourth Place -";
            case 4:
                return "- Fifth Place -";
            default:
                return "- First Place -";
        }
    }
}
