﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Object Explods after 2 seconds
public class Bomb : MonoBehaviour
{ 
    public int damage = 10;
    public int delay = 2;
    public float radius = 10f;
    public float force = 500f;
    public GameObject explosionEffect;

    // Start is called before the first frame update
        private void OnCollisionEnter(Collision other) 
        {
            if(other.gameObject.GetComponent<Rigidbody>() != null || other.gameObject.name != "Player")
            {
                Explode();
            } 
            else 
            {
                if(this.gameObject == enabled)
                Invoke("Explode", delay);
            }
        }
  
    void Explode()
    {
        //Sound Effect
        FindObjectOfType<AudioManager>().Play("BombExplosion");

        //Show Explosion
       GameObject explosion =  Instantiate(explosionEffect, transform.position, transform.rotation);
       
       //Get nearby objects
       Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
    
       foreach (Collider nearbyObject in colliders)
       {    
           //Add force to nearbyObjects with Rigidbody
           Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
           if(rb != null)
           {    
               //Add force to near by Objects
               rb.AddExplosionForce(force,transform.position, radius); //Add force to Objects with rigidbody
               Destroy(this.gameObject); //Destroy gameObject
               Destroy(explosion,2f); //Destroy particleEffect
           }
               HealthManager healthManager = nearbyObject.GetComponent<HealthManager>();
               if(healthManager !=null)
               {
                   healthManager.TakeDamage(damage);
                    //healthManager.health = healthManager.health - 10f;
               }
       }
    }
}
