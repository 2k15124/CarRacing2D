using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using System.Collections.Generic;

public class uiManager : MonoBehaviour
{
    public Button[] buttons;
    public Text scoreText;
    public TextMeshProUGUI FinalScore, HighScore;
    public AudioManager am;
    public Image fuelbarimage;
    public GameObject GOpanel,INgamePanel;

    // Use this for initialization


    public void Showscore(int score)
    {
        scoreText.text = "S C O R E : " + score;
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            am.carSound.Stop();
        }
    }

    public void Play()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            am.carSound.Play();
        }
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GameOverActivated()
    {
        foreach (Button button in buttons)
        {
            //button.gameObject.SetActive(true);
        }
    }
    public void UpdatefuelBarUI(float newfuel,float maxfuel)
    {
        float newfuelpercentage = Mathf.Clamp(newfuel / maxfuel, 0, 100);
        fuelbarimage.fillAmount = newfuelpercentage;
    }

    public void SetGoPanel(List<int> Highscore,int score)
    {
        INgamePanel.SetActive(false);
        GOpanel.SetActive(true);
        HighScore.text = $"Highscores :\n1st Best <b>{Highscore[0]}</b>\n2nd Best <b>{Highscore[1]}</b> \n3rd Best <b>{Highscore[2]}</b>";
        FinalScore.text = $"Score : {score}";
    }

}