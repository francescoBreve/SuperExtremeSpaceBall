using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Profile playerProfile;
    public GameObject levelChoice;
    public GameObject ChoicePanel;
    public GameObject newProfilePanel;
    public InputField newName;
    public Text gameVersion;   
    public Text loggedAs;
    public GameObject titleText;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if(System.IO.File.Exists(Application.persistentDataPath + "/profile.sav")){
            playerProfile = SaveSystem.LoadProfile();
            Debug.Log("Profilo caricato con successo");
            loggedAs.text = "Logged in as " + playerProfile.playerName;
            
        } else {
            Debug.Log("File di salvataggio non trovato");
            ChoicePanel.SetActive(false);
            newProfilePanel.SetActive(true);
        }
       
    }

    public void OpenLevelChoice(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        levelChoice.SetActive(true);
        ChoicePanel.SetActive(false);
        titleText.SetActive(false);
    }
    public void CloseLevelChooice(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        levelChoice.SetActive(false);
        ChoicePanel.SetActive(true);
        titleText.SetActive(true);
    }
    public void CloseGame(){
        Application.Quit();
        Debug.Log("Closing game..");
    }

    public void createNewProfile(){
        if(newName.text != ""){
            Profile newProfile = new Profile(newName.text,"");
            SaveSystem.SaveProfile(newProfile);
            newProfilePanel.SetActive(false);
            ChoicePanel.SetActive(true);
            titleText.SetActive(true);
            Refresh();
        }
        
    }

    public void Refresh(){
        
        if(System.IO.File.Exists(Application.persistentDataPath + "/profile.sav")){
            playerProfile = SaveSystem.LoadProfile();
            Debug.Log("Profilo caricato con successo");
            loggedAs.text = "Logged in as " + playerProfile.playerName;
            gameVersion.text = "Version " + playerProfile.version;
        } else {
            Debug.Log("File di salvataggio non trovato");
            ChoicePanel.SetActive(false);
            newProfilePanel.SetActive(true);
        }
    }
}
