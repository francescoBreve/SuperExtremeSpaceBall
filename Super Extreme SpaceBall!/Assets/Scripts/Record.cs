using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record
{
    private int levelID;
    private float levelTime;
    private float levelCoins;
    private float levelScore;

    public Record(int id, float time, float coins, float score){
        LevelID = id;
        LevelTime = time;
        LevelCoins = coins;
        LevelScore = score;
    }

    public int LevelID { get => levelID; set => levelID = value; }
    public float LevelTime { get => levelTime; set => levelTime = value; }
    public float LevelCoins { get => levelCoins; set => levelCoins = value; }
    public float LevelScore { get => levelScore; set => levelScore = value; }
}
