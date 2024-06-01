using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]private GameObject Instructions;
    [SerializeField]private GameObject Leaderboard;
    [SerializeField]private GameObject Customization;
    private int background_option;
    private string background_text;
    [SerializeField]private TMP_Text back_text;
    void Start()
    {
        Instructions.SetActive(false);
        Leaderboard.SetActive(false);
        Customization.SetActive(false);
        background_option = PlayerPrefs.GetInt("Background", 1);
        if (background_option == 1)
            background_text = "Right now you have forest background.";
        else if (background_option == 2)
            background_text = "Right now you have desert background";
        back_text.text = background_text;
    }
    public void Play()                  // Play button
    {
        SceneManager.LoadScene("Gra");
    }
    public void Options()               // Options button
    {
        Instructions.SetActive(true);
    }
    public void Close_Options()         // Close Options button
    {
        Instructions.SetActive(false);
    }   
    public void Leaderboards()          // Leaderboards button
    {
        Leaderboard.SetActive(true);
    }
    public void Close_Leaderboards()    // Close Leaderboards button
    {
        Leaderboard.SetActive(false);
    }
    public void Customize()             // Customize button
    {
        Customization.SetActive(true);
    }
    public void Close_customize()       // Close Customize button
    {
        Customization.SetActive(false);
        PlayerPrefs.SetInt("Background", background_option);
    }
    public void forest_option()         // Forest background option
    {
        background_option = 1;
        background_text = "Right now you have forest background";
        back_text.text = background_text;
    }
    public void beach_option()          // Beach background option
    {
        background_option = 2;
        background_text = "Right now you have desert background";
        back_text.text = background_text;
    }
    public void Quit()                  // Quit button
    {
        Application.Quit();
    }
}
