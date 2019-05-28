using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConvertedProfile
{
    public string playerName;
    public string password;
    public int gamesPlayed;
    public int lastUnlocked;
    public List<string> stringTimeRecord = new List<string>();
    public List<string> stringCoinRecord = new List<string>();
    public List<string> stringScoreRecord = new List<string>();

    private Record stringToRecord(string x){
        string[] tmp = x.Split('!');
        int levelID = int.Parse(tmp[0]);
        float levelTime = float.Parse(tmp[1]);
        float levelCoins = float.Parse(tmp[2]);
        float levelScore = float.Parse(tmp[3]);
        Record toReturn = new Record(levelID, levelTime, levelCoins, levelScore);
        return toReturn;
    }

    public Profile Revert(){
        Profile toReturn = new Profile(this.playerName, this.password);
        toReturn.gamesPlayed = this.gamesPlayed;
        toReturn.lastUnlocked = this.lastUnlocked;
        for(int i=0; i <= this.lastUnlocked; i++){
            toReturn.timeRecords.Add(stringToRecord(this.stringTimeRecord[i]));
            toReturn.coinRecords.Add(stringToRecord(this.stringCoinRecord[i]));
            toReturn.scoreRecords.Add(stringToRecord(this.stringScoreRecord[i]));
        }
        return toReturn;
    }

    public string toString(){
        string toReturn;
        toReturn = "playerName:"+playerName + System.Environment.NewLine + "password:"+password + System.Environment.NewLine + "gamesPlayed:"+ gamesPlayed + System.Environment.NewLine + "lastUnlocked:"+ lastUnlocked + System.Environment.NewLine;
        for(int i = 0; i<= this.lastUnlocked; i++){
            toReturn += "TimeRecord[" + i + "]:" + stringTimeRecord[i];
            toReturn +=System.Environment.NewLine;
            toReturn += "CoinRecord[" + i + "]:" +stringCoinRecord[i];
            toReturn +=System.Environment.NewLine;
            toReturn += "ScoreRecord[" + i + "]:" +stringScoreRecord[i];
            toReturn +=System.Environment.NewLine;
        }
        return toReturn;
    }
}
