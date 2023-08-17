using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Button[] buttons;
    public Text scoreText;
    int score;

    public AudioManager am;

    // Use this for initialization
    void Start()
    {
        score = 0;

        InvokeRepeating("scoreUpdate", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "S C O R E : " + score;
    }

    void scoreUpdate()
    {
        score += 1;
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
            button.gameObject.SetActive(true);
        }
    }
}