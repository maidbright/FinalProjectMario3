using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public float coins = 0.0f;
    public float score = 0.0f;
    public int lifes = 5;
    public float time = 200.0f;
    public float timeLeft = 0f;
    public TextMeshProUGUI timerText;
    public static GameManager Instance //prop for inst
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();  //wrks at once
            }
            return _instance;
        }
    }
    private void Awake()  //init obj
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);  //on new scene obj 'll be saved
            timeLeft = 0;
        }
        else
        {
            Destroy(gameObject);  
        }
    }


    private void Start()
    {
        timeLeft = time;
        StartCoroutine(StartTimer());
    }

    public void UpdateScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void UpdateCoinScore(float scoreToAdd)
    {
        coins += scoreToAdd;
    }

    public void UpdateLife(int lifePoint)
    {
        lifes = lifePoint < 0 ? +1 : -1;
    }

  
    public void GameOver()
    {
        TimeDelay(10.0f);
        LevelTransition.Reload();
        UpdateLife(-1);
    }


    public void StartGame()
    {
        LevelTransition.ChangeScene(1);
    }

    public void ExitGame()
    {
        TimeDelay(10.0f); //incorr
        UpdateScore(timeLeft * 100);
        LevelTransition.ChangeScene(0);
    }


    private IEnumerator StartTimer()
    {
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void UpdateTimeText() //format 00:00
    {
        if (timeLeft < 0)
        {
            timeLeft = 0;
            ExitGame();
        }

        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }


    public void TimeDelay(float seconds)
    {
        seconds *= 100;
        while(seconds > 0)
        {
            seconds -= Time.deltaTime*1;
        }
    }
}
