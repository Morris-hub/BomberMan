using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class PlayerHealthbar : MonoBehaviour
{
     //Healthbar
    private Image Healthbar;
    public float currentHealth;
    private float maxHealth = 100f;
    PlayerHealth playerhealth;


 
    // Start is called before the first frame update
    void Start()
    {
         //Find 
        Healthbar =  GetComponent<Image>();
        playerhealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
       HeahltbarScale();
    }
    

    void HeahltbarScale()
    {
        currentHealth = playerhealth.health;
        Healthbar.fillAmount = currentHealth/ maxHealth;
    }
}
