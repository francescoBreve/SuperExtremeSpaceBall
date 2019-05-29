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
        prof = FindObjectOfType<MainMenu>().playerProfile;
        if(levelId < prof.levelToPlay){
            recordPanel.SetActive(true);
            notUnlockedPanel.SetActive(false);
            leveText.text = levelName;
            float tmpTime = prof.timeRecords[levelId].LevelTime;
            timeText.text = "Best Time: " + tmpTime.ToString("f3");
            coinText.text = "Max Coin: " + prof.coinRecords[levelId].LevelCoins;
            scoreText.text = "Best Score: " + prof.scoreRecords[levelId].LevelScore;
            x.levelToLoad = levelName;
        } else if(levelId == prof.levelToPlay) {
            recordPanel.SetActive(true);
            notUnlockedPanel.SetActive(false);
            leveText.text = levelName;
            timeText.text = "Best Time: " + "not yet done";
            coinText.text = "Max Coin: " +  "not yet done";
            scoreText.text = "Best Score: " + "not yet done";
            x.levelToLoad = levelName;
        } else {
            recordPanel.SetActive(false);
            notUnlockedPanel.SetActive(true);
        }
         
    }

    
}
