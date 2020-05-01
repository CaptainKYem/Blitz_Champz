using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Start()
    {
        
    }
    private void OnPointerUpAsButton() {

	}

    //If game is over, click to go back to the start page
    public void Restart() {
        SceneManager.LoadScene("StartPage");
    }


	void OnPointerEnter() {
	}


	void OnPointerExit() {
		
	}
    void Update()
    {
        
    }
}
