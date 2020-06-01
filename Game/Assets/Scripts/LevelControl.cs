using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
     
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Man")
        {
            SceneManager.LoadScene("Level 2");
            //loads the level 2 scene
        }
    }
}
