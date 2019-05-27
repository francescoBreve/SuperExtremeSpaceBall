using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile
{
    //--------
    public string playerName;
    public string password;
    public int gamesPlayed;
    public int lastUnlocked;
    public List<Record> timeRecords = new List<Record>();
    public List<Record> coinRecords  =  new List<Record>();
    public List<Record> scoreRecords =  new List<Record>();

    public Profile(string name, string pass){
        playerName = name;
        password = pass;
        gamesPlayed = 0;
        timeRecords.Add(new Record(0, 12.2f , 5, 1230));
        coinRecords.Add(new Record(0, 12.2f , 5, 1230));
        scoreRecords.Add(new Record(0, 12.2f , 5, 1230));
    }

    public void addGame(Record x){
        if(lastUnlocked >= x.LevelID){
            if( x.LevelTime <= timeRecords[x.LevelID].LevelTime){
                timeRecords[x.LevelID] = x;
            }
            if( x.LevelCoins >= coinRecords[x.LevelID].LevelCoins){
                coinRecords[x.LevelID] = x;
            }
            if( x.LevelScore >= scoreRecords[x.LevelID].LevelScore){
                scoreRecords[x.LevelID] = x;
            }
        } else if(lastUnlocked < x.LevelID){
            lastUnlocked = x.LevelID;
            timeRecords.Add(x);
            coinRecords.Add(x);
            scoreRecords.Add(x);
        }
    }

    private string recordToString(Record x){
        string toReturn;
        toReturn = x.LevelID + "!" + x.LevelTime + "!" + x.LevelCoins + "!" + x.LevelScore;
        return toReturn;
    }

    

    public ConvertedProfile Convert(){
        ConvertedProfile toReturn = new ConvertedProfile();
        toReturn.playerName = this.playerName;
        toReturn.password = this.password;
        toReturn.gamesPlayed = this.gamesPlayed;
        toReturn.lastUnlocked = this.lastUnlocked;
        for(int i = 0; i <= this.lastUnlocked; i++){
            toReturn.stringTimeRecord.Add(recordToString(timeRecords[i]));
            toReturn.stringCoinRecord.Add(recordToString(coinRecords[i]));
            toReturn.stringScoreRecord.Add(recordToString(scoreRecords[i]));
        }
        return toReturn;
    }



}
