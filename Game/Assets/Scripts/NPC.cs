using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool displayText;
    string[] messages = new string[]
    { "Welcome", "Try to not die", "Finish the game", "Enjoy" };
    

    void Update()
    {
        while (displayText)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                displayText = false;
            }
            else
            {
                displayText = true;
                break;
            } 

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Man")
        {
            bool displayText = true;
        }
        if(displayText) 
        {   
            //for (int i = 0; i < messages.Length() ; i++) 
            foreach(string message in messages)
            {
                //string res = messages[i];
                string res = message;
            }
        }
    }
}

    

    