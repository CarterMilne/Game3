using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMelee : MonoBehaviour
{
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        //play attack animation
        //detect eminines in range of attack
        //damage to the enemies
    }
}
