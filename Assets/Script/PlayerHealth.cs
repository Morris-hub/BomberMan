using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour

{

    public float health = 100f;
    public bool getDamage = true;

   
   

   public float TakeDamage(float amount)
    {
        health = health -amount;

        if(health <= 0 && getDamage == true)
        {
            this.gameObject.SetActive(false);
        }

     return health; 
    }
    public float AddHealth(float healthpoint)
    {
        health = health + healthpoint;
        if(health > 100){
            health = 100;
        }
        return health;
    }

   

    
}


