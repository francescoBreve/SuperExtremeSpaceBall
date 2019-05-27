using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Profile playerProfile;
    public GameObject levelChoice;
    public GameObject ChoicePanel;

    // Start is called before the first frame update
    void Start()
    {
        if(System.IO.File.Exists(Application.persistentDataPath + "/profile.sav")){
            playerProfile = SaveSystem.LoadProfile();
            Debug.Log("Profilo caricato con successo");
        } else {
            Debug.Log("File di salvataggio non trovato");
            playerProfile = new Profile("TmpUser", "");
        }
    }

    public void OpenLevelChoice(){
        levelChoice.SetActive(true);
        ChoicePanel.SetActive(false);
    }
    public void CloseLevelChooice(){
        levelChoice.SetActive(false);
        ChoicePanel.SetActive(true);
    }
    public void CloseGame(){
        Application.Quit();
        Debug.Log("Closing game..");
    }
}
