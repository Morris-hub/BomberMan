using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorswitch : MonoBehaviour
{


    public float speed = 1.0f;
    public Color startColor;
    public Color endColor;
    float startTime;

    //public float switchTime = 3f;
  

    public bool repeatable = false;

        // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

       //startColor = GetComponent<MeshRenderer>().material.color;
       // StartCoroutine(Colorflick());
    }

    // Update is called once per frame
    void Update()
    {
        //Colorflick();
       ColorChange();
    } 

    
/*
        IEnumerator Colorflick()
        {       
            while(this.gameObject == enabled){
            GetComponent<MeshRenderer>().material.color = endColor;

            yield return new WaitForSeconds(switchTime);

            GetComponent<MeshRenderer>().material.color= startColor;
            }

        }
    */
    void fastChange()
    {  
        while(this.gameObject == enabled)
        {
        float t = (Mathf.Sin(Time.time -startTime) * speed);
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);

        }


    }

    void ColorChange()
    {
          if(!repeatable)
        {
            float t = (Time.time -startTime) * speed;
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        }
        else
        {
            float t = (Mathf.Sin(Time.time - startTime) * speed);
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        }

    }
    
}
