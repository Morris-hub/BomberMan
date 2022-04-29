using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBomb : MonoBehaviour
{
    
   public GameObject itemPrefab;
   private GameObject item;
   public float throwForce = 20f;
   public Transform tempParent;

   public int damage = 10;
    public int delay = 2;
    public float radius = 10f;
    public float force = 500f;
    public GameObject explosionEffect;


    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
           ThrowItem();
       }
       else if(Input.GetMouseButtonDown(1))
       {
           PlaceItem();
       }
    }

   void ThrowItem()
    {
        item = Instantiate(itemPrefab, tempParent.position, tempParent.rotation);//Create Item
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.SetParent(tempParent.transform);// Set prefab as child
         //item.GetComponent<Rigidbody>().velocity = Vector3.zero;
         //item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        //Reset Physics
        item.GetComponent<Rigidbody>().isKinematic = false;
        Rigidbody rb = item.GetComponent<Rigidbody>();
         item.transform.SetParent(null);
        
        //Throw
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    void PlaceItem()
    {
        //Place Item where it was Initiate
        item = Instantiate(itemPrefab, tempParent.position, tempParent.rotation);
        item.GetComponent<Rigidbody>().isKinematic = true;
    }



     private void OnCollisionEnter(Collision other) 
        {
            if(other.gameObject.GetComponent<Rigidbody>() != null && other.gameObject.name != "Player")
            {
                Explode();
            } 
            else 
            {
                if(item == enabled)
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
               Destroy(item); //Destroy gameObject
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
