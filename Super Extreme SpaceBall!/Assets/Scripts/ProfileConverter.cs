using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ProfileConverter
{

    public ConvertedProfile Convert(Profile profile){
        ConvertedProfile toReturn = new ConvertedProfile();
        toReturn.playerName = profile.PlayerName;
        toReturn.password = profile.Password;
        toReturn.gamesPlayed = profile.GamesPlayed;

        int numberOfLevels = profile.playerRecordsTime.Length;
        for(int i = 1; i<=numberOfLevels; i++) {
            toReturn.stringTimeRecord[i] = recordToString(profile.playerRecordsTime[i]);
        }
        for(int i = 1; i<=numberOfLevels; i++) {
            toReturn.stringCoinRecord[i] = recordToString(profile.playerRecordsCoin[i]);
        }
        for(int i = 1; i<=numberOfLevels; i++) {
            toReturn.stringScoreRecord[i] = recordToString(profile.playerRecordsScore[i]);
        }
        return toReturn;
    }

    public Profile RevertProfile(ProfileConverter toRevert){
        Profile x;
        x = new Profile(playerName, password);
        return x;
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
