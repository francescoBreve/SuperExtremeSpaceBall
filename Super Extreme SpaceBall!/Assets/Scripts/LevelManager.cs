using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public const float FPS_MODIFIER = 61;

    //System variables
    private Player player;
    public string currentScene;
    public string nextScene;
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject levelClearMenu;
    

    public Text endGameStage;
    public Text endGameTime;
    public Text endGameCoin;
    public Text endGameScore;
    

    //Gameplay variables
    public float loseHeight = -5;
    public int playerCoins;
    private float startTime;
    public float playerTime;
    public Text timeText;
    public Text coinText;
    private string timeConverted;
    private bool levelEnded = false;
    



    
    void Start()
    {
        player = FindObjectOfType<Player>();
        
        playerCoins = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

   
    }

    void Update()
    {
        if(player.transform.position.y < loseHeight){
            Reload();
        }

        if(!player.hasMoved){
            startTime = Time.time;
        }

        if(!levelEnded){
            DrawTimer();
            DrawCoinCounter();

            if(Input.GetKeyDown(KeyCode.Escape)){
                if(isPaused){
                    Resume();
                } else {
                    Pause();
                }
            }
        }
        
    }

    public void FinishLevel(){
        levelEnded = true;
        Time.timeScale = 0.0f;
        isPaused = true;
        levelClearMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        endGameStage.text = currentScene;
        endGameTime.text = "Time: " + timeConverted;
        endGameCoin.text = "Coins: " + playerCoins;

        endGameScore.text = "Score: " + CalcuateScore();
    }

    private void DrawTimer(){
            playerTime = Time.time - startTime;

            //int hours = ((int) playerTime/3600);
            int minutes = ((int) playerTime/60);
            float seconds = (playerTime%60);
            //string hoursString;
            string minutesString;
            string secondsString;

            /* 
            if(hours <=  9){
                hoursString = "0" + hours.ToString();
            } else {
                hoursString = hours.ToString();
            }
            */
            if(minutes <=  9){
                minutesString = "0" + minutes.ToString();
            } else {
                minutesString = minutes.ToString();
            }
            if(seconds <=  9){
                secondsString = "0" + seconds.ToString("f3");
            } else {
                secondsString = seconds.ToString("f3");
            }
            timeConverted = minutesString + ":" + secondsString;
            timeText.text = timeConverted;
    }
    
    public void DrawCoinCounter(){
        coinText.text = "Coins: " + playerCoins;
    }

    public void Resume()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    
    }

    public void Pause()
    {
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        
    }

    public void ExitToMenu(){
        Debug.Log("Going to menu..");
        Application.Quit();
        Resume();
    }

    public void Reload(){
        SceneManager.LoadScene(currentScene);
        Resume();
    }

    public void LoadNextScene(){
        SceneManager.LoadScene(nextScene);
        Resume();
    }

    private int CalcuateScore(){
        return 1;
    }
}
