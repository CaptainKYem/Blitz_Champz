using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject loadPlayerOptions;

    //starts the game
    public void PlayGame ()
    {
        SceneManager.LoadScene("BlitzChampzGame");
    }

    //if 2 players are selected
    public void TwoPlayer()
    {
        Manager.PlayerCount = 2;
        PlayGame();
    }

    //if 3 players are selected
    public void ThreePlayer()
    {
        Manager.PlayerCount = 3;
        PlayGame();
    }

    //if 4 players are selected
    public void FourPlayer()
    {
        Manager.PlayerCount = 4;
        PlayGame();
    }

    
    public void OpenPlayerOptions()
    {
        loadPlayerOptions.SetActive(true);
    }

    //If tutorial button is clicked open a new website
    public void LoadTutorial()
    {
        Application.OpenURL("http://blitzchampz.com/rules/");
    }


    

}
