using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Profile
{
    //--------
    public string playerName;
    public string password;
    public int gamesPlayed;
    public int levelToPlay;
    public string version;
    public List<Record> timeRecords = new List<Record>();
    public List<Record> coinRecords  =  new List<Record>();
    public List<Record> scoreRecords =  new List<Record>();

    public Profile(string name, string pass){
        playerName = name;
        password = pass;
        gamesPlayed = 0;
        levelToPlay = 1;
        timeRecords.Add(new Record(0, 0 , 0, 0));
        coinRecords.Add(new Record(0, 0 , 0, 0));
        scoreRecords.Add(new Record(0, 0 , 0, 0));
        version = "0.5.2";
    }
   

    public void addGame(Record x){
        if(x.LevelID < levelToPlay){ //se ho già giocato il livello
            if( x.LevelTime <= timeRecords[x.LevelID].LevelTime){
                timeRecords[x.LevelID] = x;
            }
            if( x.LevelCoins >= coinRecords[x.LevelID].LevelCoins){
                coinRecords[x.LevelID] = x;
            }
            if( x.LevelScore >= scoreRecords[x.LevelID].LevelScore){
                scoreRecords[x.LevelID] = x;
            }
        }
        if(x.LevelID == levelToPlay){ //se sto cercando di sbloccare il nuovo livello
            levelToPlay++;
            timeRecords.Add(x);
            coinRecords.Add(x);
            scoreRecords.Add(x);
        }
        gamesPlayed++;
        SaveSystem.SaveProfile(this);
    } 

    
    public string toString(){
        string toReturn;
        toReturn = "playerName:"+playerName + System.Environment.NewLine + "password:"+password + System.Environment.NewLine +  "GameVersion:" + version + System.Environment.NewLine + "gamesPlayed:"+ gamesPlayed + System.Environment.NewLine + "levelToPlay:"+ levelToPlay + System.Environment.NewLine;
        for(int i = 0; i< this.levelToPlay; i++){
            toReturn += "TimeRecord[" + i + "]:" + timeRecords[i];
            toReturn +=System.Environment.NewLine;
            toReturn += "CoinRecord[" + i + "]:" + coinRecords[i];
            toReturn +=System.Environment.NewLine;
            toReturn += "ScoreRecord[" + i + "]:" + scoreRecords[i];
            toReturn +=System.Environment.NewLine;
        }
        return toReturn;
    }


}
