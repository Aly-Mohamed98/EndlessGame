using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public Text Health;
    public Text Score;
    public static int PlayerHealth;
    public static int score;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        score = 0;
        PlayerHealth = 3;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "Health :" + PlayerHealth;
        Score.text = "Score : " + score; 
        if(gameOver){
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

    }
}
