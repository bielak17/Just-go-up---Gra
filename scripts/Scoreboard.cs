using UnityEngine;
using System.IO;

public class Scoreboard : MonoBehaviour
{
    private int maxHighscores = 5;                                                                  //max number of highscores to save
    [SerializeField] private Transform highscoreHolder;
    [SerializeField] private GameObject scoreboardEntryObject;

    [Header ("TEST")]
    [SerializeField] ScoreboardEnrtyData testEntry = new ScoreboardEnrtyData();

    private string highscorespath => $"{Application.persistentDataPath}/highscores.json";           //path to json file with highscores
    private void Start()
    {
        ScoreboardSaveData savedScores = LoadScores();
        SaveScores(savedScores);
        UpdateUI(savedScores);
    }
    [ContextMenu("Add Test Score")]
    public void AddTestScore()
    {
        AddScore(testEntry);
    }
    public void AddScore(ScoreboardEnrtyData entrydata)                         //adding new score to highscore list if it is high enough
    {
        ScoreboardSaveData savedScores = LoadScores();
        bool scoreAdded = false;
        for(int i = 0; i < savedScores.highscores.Count; i++)                   //checking if new score is higher than any of the saved scores
        {
            if(entrydata.score > savedScores.highscores[i].score)               //adding new score to the list
            {
                savedScores.highscores.Insert(i, entrydata);
                scoreAdded = true;
                break;
            }
        }
        if(!scoreAdded && savedScores.highscores.Count < maxHighscores)         //if new score is not higher than any of the saved scores and there is still space in the list
        {
            savedScores.highscores.Add(entrydata);
        }
        if(savedScores.highscores.Count > maxHighscores)                        //if there are more scores than maxHighscores, remove the lowest ones
        {
            savedScores.highscores.RemoveRange(maxHighscores, savedScores.highscores.Count - maxHighscores);
        }
        SaveScores(savedScores);
        UpdateUI(savedScores);
    }
    private void UpdateUI(ScoreboardSaveData savedScores)
    {
        foreach(Transform child in highscoreHolder)                         //clearing the list of highscores
        {
            Destroy(child.gameObject);
        }
        foreach(ScoreboardEnrtyData score in savedScores.highscores)        //adding highscores onto the screen
        {
            GameObject entry = Instantiate(scoreboardEntryObject, highscoreHolder);
            entry.GetComponent<ScoreboardEntryUI>().Initialize(score);
        }
    }
    private ScoreboardSaveData LoadScores()
    {
        if (!File.Exists(highscorespath))                       //if there is no file with highscores, create a new one
        {
            File.Create(highscorespath).Dispose();
            return new ScoreboardSaveData();
        }
        using(StreamReader stream = new StreamReader(highscorespath))   //reading highscores from json file
        {
            string json = stream.ReadToEnd();
            if (JsonUtility.FromJson<ScoreboardSaveData>(json) != null) //if file is not empty, return highscores if it is return empty list
                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            else
                return new ScoreboardSaveData();
        }
    }
    private void SaveScores(ScoreboardSaveData scores)
    {
        using(StreamWriter stream = new StreamWriter(highscorespath))       //writing highscores to json file
        {
            string json = JsonUtility.ToJson(scores, true);
            stream.Write(json);
        }
    }
}
