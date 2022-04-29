using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager: MonoBehaviour
{

    public float health = 100f;
    //public int giveDamage;

    

   public float TakeDamage(float amount)
    {

        health = health - amount;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }

     return health; 
    }

    
}
