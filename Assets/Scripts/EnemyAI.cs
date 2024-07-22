using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    
    
    //Call in the enemy's turn
    //Enemy gains access to player health
    //Enemy interacts with attack UI - dealing damage
    //Enemy turn ends, switch to player's turn

    void Start()
    {
        GameObject otherObject = GameObject.Find("PlayerHealth");

        if (otherObject != null)
        {
            Healthbar Healthbarcomponent = otherObject.GetComponent<Healthbar>();

            if(Healthbarcomponent != null )
            {
                Healthbarcomponent.TakeDamage(10);
            }




        }
    }

    
    void Update()
    {
        
    }
}
