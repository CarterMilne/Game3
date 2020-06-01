using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // this will load the next scene in the index when pressed the play button
    }
    public void Quit()
    {
        Application.Quit();
        // this lets us quit the application
    }
}
