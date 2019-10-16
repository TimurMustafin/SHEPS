using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameMaster : MonoBehaviour
{
    public float Timer;
    public Text Countdown;
    public GameObject GameOver;
    public GameObject YouWon;
    
    public static bool isOver;
    public static bool isWinner;
    public static event Action OnStopGame;
   
    
    void Start()
    {
        Time.timeScale = 1f;

        AchivmentSystem.OnAchive += () => {
            if (!isWinner)
            {
                Debug.Log("EventHandler: Achive!!");
                StartCoroutine(YouAreWon());
            }            
        };

        ShepsMotion.OnShepsDying += () => {
            Debug.Log("EventHandler: Sheps is Dead!!!");
            GameIsOver();
        };

    }
    
    void Update()
    {
        if (Timer < 0)
        {
            GameIsOver();
            return;
        }
        Timer -= Time.deltaTime;
        Countdown.text = Mathf.Round((Timer /* 10000*/)).ToString();          
    }
   
    public void GameIsOver()
    {
        Debug.Log("Method: GameIsOver!!!");
        if (!isOver)  
            StartCoroutine(OveringGame());
    }

    IEnumerator OveringGame()
    {
        Debug.Log("Coroutine: OveringGame");

        GameOver.SetActive(true);
        isOver = true;      

        float timer = 3f;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(0);       
    }

    IEnumerator YouAreWon()
    {
        Debug.Log("Coroutine: YouAreWon");

        isWinner = true;
        Time.timeScale = 0.3f;
        YouWon.SetActive(true);        
        float timer = 1f;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        if (SceneManager.GetActiveScene().name == "Level03")
        {
            SceneManager.LoadScene(0);
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
