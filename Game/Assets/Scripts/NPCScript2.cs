using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPCScript2 : MonoBehaviour
{
    GameObject Panel;
    //calling the panel in game
    public bool displayText;
    // making a boolean called display text able to be set as true or false
    TextMeshProUGUI textBox;
    // calling the textbox mesh pro edit on GUI textbox
    string[] messages = new string[]
    { "Good Job, on reaching this far!", "You have be transported to another location and reach the door to make it to the end!", 
     "You still need to kill everything in sight"
    ,"But the Machine Gun touret you need to touch to disable","Good Luck!"};
    // these are the messages that the NPC is going to display
    int index;
    // calling the index as an integer
    float lastMessageChange;
    // a float for the last time the message changed
    [SerializeField] float changeTime;
    // allows us to change the change time inbetween in the inspector
    void Start()
    {
        Panel = transform.Find("Canvas").Find("Panel").gameObject;
        textBox = Panel.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        // this calls the text from the NPC so we can display it

    }
    void Update()
    {
        Panel.SetActive(displayText);
        // allows us to show the active display text
        if (lastMessageChange + changeTime < Time.time && displayText)
        {
            lastMessageChange = Time.time;
            index++;
            // the last time the message was changed addes to the time
            if (index >= messages.Length)
            {
                displayText = false;
                // if the messages avaible to display then it stops 
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(AddToText(messages[index]));
                // this lets us run two coroutines that run at different speeds.
                // and adds to the message in the index
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Man")
        {
            displayText = true;
            // when the man collides with the NPC then we make display text as true
        }
        if (displayText)
        {
            index = 0;
            lastMessageChange = Time.time;
            StopAllCoroutines();
            StartCoroutine(AddToText(messages[0]));
            // this lets us if it is true then displays the text
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Man")
        {
            displayText = false;
            // if its false and the man isn't in the collider then we dont play the display text
        }
    }
    IEnumerator AddToText(string textToAdd)
    {
        textBox.text = "";
        // we set the initial text to nothing
        foreach (char c in textToAdd)
        {
            textBox.text += c;
            yield return null;
            // this lets us have every letter in the string array list be c as we can display it in almost a delayed effect 
        }
    }

}



