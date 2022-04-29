using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 0.1f;
   private void OnCollisionEnter(Collision other) {
       if(other.gameObject.name == "Player")
       { 

           GameObject Player = other.gameObject;
           PlayerHealth playerhealth = Player.GetComponent<PlayerHealth>();
            if(playerhealth!=null)
            {

                playerhealth.TakeDamage(damage);
                //healthManager.health = healthManager.health - 10f;
            }
            Destroy(this.gameObject);
       }
       else
       {
           Destroy(this.gameObject,3f);
       }
   }
}
