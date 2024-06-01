using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardEntryUI : MonoBehaviour              //UI to display highscores from json file
{
    public TMP_Text highscoreText;
    public void Initialize(ScoreboardEnrtyData entry)
    {
        highscoreText.text = entry.score.ToString();
    }
}
