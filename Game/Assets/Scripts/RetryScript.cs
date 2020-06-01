using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Level 1");  
        //loading scene manager level one when retry button is pressed
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu and Intro");
        //loadis the menu when the button is pressed
    }
    public void Quit()
    {
        Application.Quit();
        // allows us to quit it
    }
}
