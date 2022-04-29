using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class HealthbarScript : MonoBehaviour
{

    //Healthbar
    private Image Healthbar;
    public float currentHealth;
    private float maxHealth = 100f;
    HealthManager Enemyhealth;


 
    // Start is called before the first frame update
    void Start()
    {
        //Find 
        Healthbar =  GetComponent<Image>();
        Enemyhealth = FindObjectOfType<HealthManager>();


    }

    // Update is called once per frame
    void Update()
    {
       HeahltbarScale();
    }
    

    void HeahltbarScale()
    {
        currentHealth = Enemyhealth.health;
        Healthbar.fillAmount = currentHealth/ maxHealth;
    }
}
