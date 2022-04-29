using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
   public float healthpoint = 10f;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player")
        {
            GameObject Player = other.gameObject;
            PlayerHealth playerHealth = Player.GetComponent<PlayerHealth>();

            if(playerHealth != null)
            {
                playerHealth.AddHealth(healthpoint);
            }
        }
    }
}
