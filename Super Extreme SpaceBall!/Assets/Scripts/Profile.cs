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
    }

    public void addGame(Record x){
        if(levelToPlay == x.LevelID){
            Debug.Log("profilo:" + x.toString());
            levelToPlay++;
            timeRecords.Add(x);
            coinRecords.Add(x);
            scoreRecords.Add(x);
        } else if(levelToPlay < x.LevelID){
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
        SaveSystem.SaveProfile(this);
    }

    private string recordToString(Record x){
        string toReturn;
        Debug.Log(x.toString());
        toReturn = x.LevelID + "!" + x.LevelTime + "!" + x.LevelCoins + "!" + x.LevelScore;
        return toReturn;
    }

    

    public ConvertedProfile Convert(){
        ConvertedProfile toReturn = new ConvertedProfile();
        toReturn.playerName = this.playerName;
        toReturn.password = this.password;
        toReturn.gamesPlayed = this.gamesPlayed;
        toReturn.levelToPlay = this.levelToPlay;
        for(int i = 0; i < this.levelToPlay; i++){
            Debug.Log("Record to string of " + i + ":" + recordToString(timeRecords[i]));
            toReturn.stringTimeRecord.Add(recordToString(timeRecords[i]));
            Debug.Log("Record to string of " + i + ":" + recordToString(coinRecords[i]));
            toReturn.stringCoinRecord.Add(recordToString(coinRecords[i]));
            Debug.Log("Record to string of " + i + ":" + recordToString(scoreRecords[i]));
            toReturn.stringScoreRecord.Add(recordToString(scoreRecords[i]));
        }
        return toReturn;
    }

    public string toString(){
        string toReturn;
        toReturn = "playerName:"+playerName + System.Environment.NewLine + "password:"+password + System.Environment.NewLine + "gamesPlayed:"+ gamesPlayed + System.Environment.NewLine + "levelToPlay:"+ levelToPlay + System.Environment.NewLine;
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
