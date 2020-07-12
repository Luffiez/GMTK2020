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
    public float timer;
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
        filePath = Application.persistentDataPath + $"/scoreboard_data.txt";
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
        Level levelExists = GetLevel(sceneName);
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

        score.timer = timer;

        score.date = System.DateTime.Today.ToString("dd / MM / yyyy");
        levelExists.scoreList.Add(score);

        SaveScoreboard();
    }

    Level GetLevel(string level)
    {
        return scoreboard.levels.Find(x => x.levelName == level);
    }

    public Score GetHighestScore(string sceneName)
    {
        Level level = GetLevel(sceneName);

        if(level == null || level.scoreList.Count > 0)
        {
            return null;
        }

        Score highest = level.scoreList[0];
        
        foreach (Score score in level.scoreList)
        {
            if (score.timer < highest.timer)
                highest = score;
        }

        return highest;
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
