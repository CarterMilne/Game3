using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPC : MonoBehaviour
{
    GameObject Panel;
    public bool displayText;
    TextMeshProUGUI textBox;
    string[] messages = new string[]
    { "I am your Guide", "Your Objective is to kill everything in sight", "And hopefully not die, but you can always restart", "Also be sure to stay in bounds to not instant die"
    ,"Try and reach the door at the each of the levels to continue","Good Luck!"};
    int index;
    float lastMessageChange;
    [SerializeField] float changeTime;
    void Start()
    {
        Panel = transform.Find("Canvas").Find("Panel").gameObject; 
        textBox = Panel.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        
    }
    void Update()
    {
        Panel.SetActive(displayText);
        if(lastMessageChange + changeTime < Time.time && displayText)
        { 
            lastMessageChange = Time.time;
            index++;
            if (index >= messages.Length)
            {
                displayText = false;
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(AddToText(messages[index]));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Man")
        {
            displayText = true;
        }
        if(displayText) 
        {
            index = 0;
            lastMessageChange = Time.time;
            StopAllCoroutines();
            StartCoroutine(AddToText(messages[0]));
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Man")
        {
            displayText = false;
        }
    }
    IEnumerator AddToText(string textToAdd)
    {
        textBox.text = "";
        foreach (char c in textToAdd)
        {
            textBox.text += c;
            yield return null;
        }
    }

}



