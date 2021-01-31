using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuScript : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(LevelNames.INTRO);// Need scene name here
    } 

    public void Quit()
    {
        Debug.Log ("QUIT OPTION");
        Application.Quit();
    }

    
}
