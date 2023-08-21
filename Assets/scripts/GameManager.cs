using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public static float Gamespeed;
    public float test_gamespeed;
    public float initialgamespeed;
    public float updatespeedtime;
    public float speedchangesovertime;
    public uiManager ui;
    int score;
   
    public static bool Gameover { get; private set; }

    private const string HighScoreKey = "HighScore";
    private const int NumberOfScoresToTrack = 3;
    private List<int> highScores = new List<int>();


    private void Awake()
    {
        Gameover = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadHighScores();

        score = 0;
        if (!Gameover)
        {
            InvokeRepeating("scoreUpdate", 1.0f, 1.0f);
        }
        Gamespeed = initialgamespeed;
        StartCoroutine(gamespeed_updater(updatespeedtime));
    }

    // Update is called once per frame
    void Update()
    {
        test_game_speed_updater();
    }
    void test_game_speed_updater()
    {
        if (Gamespeed != test_gamespeed)
        {  Debug.Log("Speed changed");
        Gamespeed = test_gamespeed; }
    }

    IEnumerator gamespeed_updater(float intime)
    {
        yield return new WaitForSeconds(intime);
        Gamespeed += speedchangesovertime;
        test_gamespeed += speedchangesovertime;
    }
    void scoreUpdate()
    {
        score += 1;
        ui.Showscore(score);
    }

    public void setGameover()
    {
        SaveHighScore(score);
        Gameover = true;
        ui.SetGoPanel(highScores, score);
    }
    public void SaveHighScore(int newScore)
    {
        highScores.Add(newScore);
        highScores.Sort((a, b) => b.CompareTo(a)); // Sort in descending

        if (highScores.Count > NumberOfScoresToTrack)
        {
            highScores.RemoveAt(highScores.Count - 1); // Remove the lowest
        }

        SaveHighScores();
    }

    public List<int> GetHighScores()
    {
        return highScores;
    }

    private void LoadHighScores()
    {
      

        for (int i = 0; i < NumberOfScoresToTrack; i++)
        {
            int score = PlayerPrefs.GetInt($"{HighScoreKey}{i}", 0);
            highScores.Add(score);
        }
    }

    private void SaveHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt($"{HighScoreKey}{i}", highScores[i]);
        }

        PlayerPrefs.Save();
    }



}
