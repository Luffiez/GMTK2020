using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;

[System.Serializable]
public class Score
{
    public int honks;
    public string timer;
    public string date;
}

[System.Serializable]
public class Scoreboard
{
   public List<Level> levels;
}

[System.Serializable]
public class Level
{
    public string levelName;
    public List<Score> scoreList;
}

public class HighScoreManager : MonoBehaviour
{
    string filePath;

    public static HighScoreManager instance = null;
    Scoreboard scoreboard;

    public Scoreboard Scoreboard { get => scoreboard; }

    void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        filePath = Application.persistentDataPath + $"/{sceneName}_scoreboard.txt";
        scoreboard = LoadScoreboardData();

        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private Scoreboard LoadScoreboardData()
    {
        string jsonString;
        if (!File.Exists(filePath))
        {
            jsonString = CreateEmptyScoreboard();
        }
        else
        {
            StreamReader reader = new StreamReader(filePath);
            jsonString = reader.ReadLine();
            reader.Close();
        }

        Scoreboard board = JsonUtility.FromJson<Scoreboard>(jsonString);
        if (board == null)
        {
            jsonString = CreateEmptyScoreboard();
            board = JsonUtility.FromJson<Scoreboard>(jsonString);
        }

        return board;
    }

    public void AddToScoreboard(string sceneName, int honks, float timer)
    {
        Level levelExists = scoreboard.levels.Find(x => x.levelName == sceneName);
        if (levelExists == null)
        {
            List<Score> scores = new List<Score>();

            Level level = new Level
            {
                levelName = sceneName,
                scoreList = scores
            };
            levelExists = level;
            scoreboard.levels.Add(level);
        }

        Score score = new Score();
        score.honks = honks;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        score.timer = $"{minutes}:{seconds}";

        score.date = System.DateTime.Today.ToString("dd / MM / yyyy");
        levelExists.scoreList.Add(score);

        SaveScoreboard();
    }

    public List<string> LoadCompletedLevels()
    {
        List<string> completedLevels = new List<string>();

        foreach (Level level in scoreboard.levels)
        {
            if(string.IsNullOrEmpty(level.levelName))
            {
                completedLevels.Add(level.levelName);
            }
        }

        return completedLevels;
    }

    string SaveScoreboard()
    {
        string jsonString = JsonUtility.ToJson(scoreboard);
        StreamWriter writer = new StreamWriter(File.Create(filePath));
        writer.Write(jsonString);
        writer.Flush();
        writer.Close();
        return jsonString;
    }

    string CreateEmptyScoreboard()
    {
        Scoreboard scoreboard = new Scoreboard();
        scoreboard.levels = new List<Level>();
      
        string jsonString = JsonUtility.ToJson(scoreboard);
        StreamWriter writer = new StreamWriter(File.Create(filePath));
        writer.Write(jsonString);
        writer.Flush();
        writer.Close();
        return jsonString;
    }
};
