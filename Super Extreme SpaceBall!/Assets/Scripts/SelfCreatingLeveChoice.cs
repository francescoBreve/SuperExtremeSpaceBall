using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelfCreatingLeveChoice : MonoBehaviour
{   
    public int levelId;
    public string levelName;
    private Text innerText;
    public GameObject recordPanel;
    public GameObject notUnlockedPanel;
    public Text leveText;
    public Text timeText;
    public Text coinText;
    public Text scoreText;
    public Button playButton;
    private PlayButton x;

    private Profile prof;


    void Start()
    {
        innerText = GetComponentInChildren<Text>();
        innerText.text = "" + levelId;
        x = playButton.GetComponent<PlayButton>();
        prof = FindObjectOfType<MainMenu>().playerProfile;
    }

    public void DrawPlayWindow(){
        
        Debug.Log(prof);
        prof = FindObjectOfType<MainMenu>().playerProfile;
        if(levelId <= prof.lastUnlocked){
            recordPanel.SetActive(true);
            notUnlockedPanel.SetActive(false);
            leveText.text = levelName;
            timeText.text = "Best Time: " + prof.timeRecords[levelId].LevelTime;
            coinText.text = "Max Coin: " + prof.coinRecords[levelId].LevelCoins;
            scoreText.text = "Best Score: " + prof.scoreRecords[levelId].LevelScore;
            x.levelToLoad = levelName;
        } else {
            recordPanel.SetActive(false);
            notUnlockedPanel.SetActive(true);
        }
         
    }

    
}
