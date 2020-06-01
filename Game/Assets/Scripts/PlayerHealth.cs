using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    MovementScript movementScript;
    // calling the man's movement script varaible name

    public Slider slider;
    // this is from the inspecter and is in realtion to the health bar and the amount of health filled
    
    public void SetHealth(float health)
    {
        slider.value = health;
        // the sliders value in the inspector is equal to the players health
    } 
}



