using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ProfileConverter
{
    private string playerName;
    private string password;
    private int gamesPlayed;

    private string[] stringTimeRecord;
    private string[] stringCoinRecord;
    private string[] stringScoreRecord;

    public void ConvertProfile(Profile profile){
        int numberOfLevels = profile.playerRecordsTime.Length;
        for(int i = 1; i<=numberOfLevels; i++) {
            stringTimeRecord[i] = recordToString(profile.playerRecordsTime[i]);
        }
        for(int i = 1; i<=numberOfLevels; i++) {
            stringCoinRecord[i] = recordToString(profile.playerRecordsCoin[i]);
        }
         for(int i = 1; i<=numberOfLevels; i++) {
            stringScoreRecord[i] = recordToString(profile.playerRecordsScore[i]);
        }
    }   

    public string recordToString(Record x){
        string toReturn = "";
        toReturn = x.LevelID + "!" + x.LevelTime + "!" + x.LevelCoins + "!" + x.LevelScore;
        return toReturn;
    }

    public Record stringToRecord(string x){
        string[] splitted = x.Split('!');
        int lvID = Int32.Parse(splitted[0]);
        int lvTime = Int32.Parse(splitted[1]);
        int lvCoin = Int32.Parse(splitted[2]);
        int lvScore = Int32.Parse(splitted[3]);
        Record toReturn = new Record(lvID, lvTime, lvCoin, lvScore);
        return toReturn;
    }

}
