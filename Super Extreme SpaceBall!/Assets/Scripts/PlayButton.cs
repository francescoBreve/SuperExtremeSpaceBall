using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public string levelToLoad;

    public void loadLevel(){
        SceneManager.LoadScene(levelToLoad);
        //Debug.Log(levelToLoad);
    }
}
