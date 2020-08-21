using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass : MonoBehaviour
{
    // Start is called before the first frame update
    
    Profile playerProfile;

    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void inizialize(){
        playerProfile = new Profile("Saidrog" , "123");
        Debug.Log("player created");
    }

    public void addRecord(int x){
        playerProfile.addGame(new Record(x, 10.0f,3,1000));
        Debug.Log("Added record" + x);
    }
     
    public void save(){
        SaveSystem.SaveProfile(playerProfile);
        Debug.Log("player saved at " + Application.persistentDataPath);
    }

    public void load(){
        playerProfile = SaveSystem.LoadProfile();
        Debug.Log("player loaded");
    }
    
    public void stampa(){
        Debug.Log(playerProfile);
        Debug.Log(playerProfile.playerName);
        Debug.Log(playerProfile.password);
        for(int i = 0; i<=playerProfile.levelToPlay; i++){
            Debug.Log(playerProfile.timeRecords[i].LevelID);
            Debug.Log(playerProfile.timeRecords[i].LevelTime);
        }
    }
    
}
