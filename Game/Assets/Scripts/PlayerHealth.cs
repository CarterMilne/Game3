using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    MovementScript movementScript;

    public Slider slider;
    
    public void SetHealth(float health)
    {

        slider.value = health;
      
        
    }
    
}



