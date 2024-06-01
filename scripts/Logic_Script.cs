using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public float Score;
    public int multiplayer;
    public bool isAlive;
    private TMP_Text scoreText;
    [SerializeField]private TMP_Text gameOverScore;
    private player_script player;
    [SerializeField]private GameObject gameOverUI;
    private tree_move tree;
    private scrolling_background background;
    private Fruit_spawner fruit;
    private GameObject score;
    [SerializeField]private Scoreboard scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0f;
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_script>();
        tree=GameObject.FindGameObjectWithTag("Tree").GetComponent<tree_move>();
        background=GameObject.FindGameObjectWithTag("Background").GetComponent<scrolling_background>();
        fruit=GameObject.FindGameObjectWithTag("Fruit").GetComponent<Fruit_spawner>();
        score=GameObject.FindGameObjectWithTag("Score");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)                                                         //counting score and displaying it
        {
            Score += multiplayer * (Time.deltaTime);
            displayScore((int)Score);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if((int)Score%10==0 && Score>0)                                        //rampping up speed each 10 points
        {
            tree.ramping_speed+=0.35f * Time.deltaTime;
            background.ramping_speed+=0.05f * Time.deltaTime;
            player.falling_speed+=2f * Time.deltaTime;
            
        }
        if((int)Score%33==0 && Score>0)                                        //increasing fruit spawn rate each 33 points
        {
            fruit.banana_spawn_time-=0.3f * Time.deltaTime;
            fruit.strawberry_spawn_time-=0.75f * Time.deltaTime;
            fruit.watermelon_spawn_time-=0.5f * Time.deltaTime;
            fruit.lemon_spawn_time-=1f * Time.deltaTime;
        }
    }
    void displayScore(int score)                                                //function to display score
    {
        scoreText.text = score.ToString();
        gameOverScore.text = score.ToString();
    }
    public void gameOver()                                                     //function to display game over screen
    {
        gameOverUI.SetActive(true);
        displayScore((int)Score);
        score.SetActive(false);
        ScoreboardEnrtyData entry = new ScoreboardEnrtyData();
        entry.score = (int)Score;
        scoreboard.AddScore(entry);
    }
    public void restart()                                                     //restart button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()                                                        //menu button
    {
        SceneManager.LoadScene("Main Menu");
    }
}
