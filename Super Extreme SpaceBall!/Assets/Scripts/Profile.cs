using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile
{
    private string playerName;
    private string password;
    private int gamesPlayed;
    public Record[] playerRecordsTime; //array[i] = level id "i", array[1] = level 1
    public Record[] playerRecordsCoin;
    public Record[] playerRecordsScore;

    public Profile(string name , string pass)
    {
        playerName = name;
        password = pass;
        gamesPlayed = 0;
        playerRecordsTime[0] = new Record(0, 0, 0, 0);
        playerRecordsCoin[0] = new Record(0, 0, 0, 0);
        playerRecordsScore[0] = new Record(0, 0, 0, 0);
    }

    public void addGame(Record x){
        gamesPlayed ++;
        if(x.LevelTime < playerRecordsTime[x.LevelID].LevelTime){
            playerRecordsTime[x.LevelID] = x;
        }
        if(x.LevelCoins > playerRecordsCoin[x.LevelID].LevelCoins){
            playerRecordsCoin[x.LevelID] = x;
        }
        if(x.LevelScore > playerRecordsScore[x.LevelID].LevelScore){
            playerRecordsScore[x.LevelID] = x;
        }
        
    }
  
}
